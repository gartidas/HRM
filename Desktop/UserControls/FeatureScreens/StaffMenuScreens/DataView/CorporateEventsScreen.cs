using Desktop.Forms;
using Desktop.Models;
using Desktop.Responses;
using Desktop.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class CorporateEventsScreen : UserControl
    {
        private int _currentPageNumber = 1;
        private int _numberOfPages;
        private IEnumerable<Event> _corporateEvents;

        public CorporateEventsScreen()
        {
            InitializeComponent();
        }

        private async Task LoadCorporateEventsAsync()
        {
            GenericGetAllResponse<Event> response = null;

            if (nameFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllCorporateEventsAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, nameFilter: filterTextBox.Text);
            else
                response = await ApiHelper.Instance.GetAllCorporateEventsAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, locationFilter: filterTextBox.Text);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            _corporateEvents = response.Content;
            LoadListView(_corporateEvents);
        }

        private void LoadListView(IEnumerable<Event> corporateEvents)
        {
            corporateEventsListView.Clear();

            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "DateAndTime", TextAlign = HorizontalAlignment.Center, Text = "Date and time" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Location", TextAlign = HorizontalAlignment.Center, Text = "Location" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Request", TextAlign = HorizontalAlignment.Center, Text = "Request" });

            corporateEventsListView.View = View.Details;

            if (corporateEvents != null)
            {
                foreach (var corporateEvent in corporateEvents)
                {
                    var item = new ListViewItem
                    {

                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.DateAndTime.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Name));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Location));

                    if (corporateEvent.RequestDescription != null)
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.RequestDescription));

                    corporateEventsListView.Items.Add(item);
                }
            }

            corporateEventsListView.Columns[1].Width = -1;

            if (corporateEventsListView.Columns[1].Width < 300)
                corporateEventsListView.Columns[1].Width = 300;

            corporateEventsListView.Columns[2].Width = -1;

            if (corporateEventsListView.Columns[2].Width < 200)
                corporateEventsListView.Columns[2].Width = 200;

            corporateEventsListView.Columns[3].Width = -1;

            if (corporateEventsListView.Columns[3].Width < 200)
                corporateEventsListView.Columns[3].Width = 200;

            corporateEventsListView.Columns[4].Width = -1;

            if (corporateEventsListView.Columns[4].Width < 200)
                corporateEventsListView.Columns[4].Width = 200;
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadCorporateEventsAsync();
        }

        private async void filterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadCorporateEventsAsync();
        }

        private async void previousPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadCorporateEventsAsync();
        }

        private async void nextPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadCorporateEventsAsync();
        }

        private async void CorporateEventsScreen_Load(object sender, System.EventArgs e)
        {
            await LoadCorporateEventsAsync();
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            ScreenLoading.SetScreenContent(default);
            ScreenLoading.LoadScreen(24);
        }

        private void editButton_Click(object sender, System.EventArgs e)
        {
            if (corporateEventsListView.SelectedIndices.Count > 0)
            {
                foreach (var corporateEvent in _corporateEvents)
                {
                    if (corporateEvent.Name == corporateEventsListView.SelectedItems[0].SubItems[2].Text && corporateEvent.Location == corporateEventsListView.SelectedItems[0].SubItems[3].Text && corporateEvent.DateAndTime.ToString() == corporateEventsListView.SelectedItems[0].SubItems[1].Text)
                    {
                        ScreenLoading.SetScreenContent(corporateEvent.ID);
                        ScreenLoading.LoadScreen(24);
                        return;
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (corporateEventsListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var corporateEvent in _corporateEvents)
                {
                    if (corporateEvent.Name == corporateEventsListView.SelectedItems[0].SubItems[2].Text && corporateEvent.Location == corporateEventsListView.SelectedItems[0].SubItems[3].Text && corporateEvent.DateAndTime.ToString() == corporateEventsListView.SelectedItems[0].SubItems[1].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveCorporateEventAsync(corporateEvent.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            _currentPageNumber = 1;
                            await LoadCorporateEventsAsync();
                        }
                        else
                        {
                            errorLabel.Text = response.ErrorMessage;
                            errorLabel.Visible = true;
                        }

                        return;
                    }
                }
            }
        }
    }
}
