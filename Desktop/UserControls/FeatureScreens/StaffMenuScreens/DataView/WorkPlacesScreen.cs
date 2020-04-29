using Desktop.Forms;
using Desktop.Models;
using Desktop.Responses;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class WorkPlacesScreen : UserControl
    {
        private int _currentPageNumber = 1;
        private int _numberOfPages;
        private IEnumerable<WorkPlace> _workPlaces;

        public WorkPlacesScreen()
        {
            InitializeComponent();
        }

        private async Task LoadWorkPlacesAsync()
        {
            GenericGetAllResponse<WorkPlace> response = null;

            if (labelFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllWorkPlacesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, labelFilter: filterTextBox.Text);
            else
                response = await ApiHelper.Instance.GetAllWorkPlacesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, locationFilter: filterTextBox.Text);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            _workPlaces = response.Content;
            LoadListView(_workPlaces);
        }

        private void LoadListView(IEnumerable<WorkPlace> workPlaces)
        {
            workplacesListView.Clear();

            workplacesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            workplacesListView.Columns.Add(new ColumnHeader { Name = "Label", TextAlign = HorizontalAlignment.Center, Text = "Label" });
            workplacesListView.Columns.Add(new ColumnHeader { Name = "Location", TextAlign = HorizontalAlignment.Center, Text = "Location" });

            workplacesListView.View = View.Details;

            if (workPlaces != null)
            {
                foreach (var corporateEvent in workPlaces)
                {
                    var item = new ListViewItem
                    {

                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Label));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Location));

                    workplacesListView.Items.Add(item);
                }
            }

            workplacesListView.Columns[1].Width = -1;

            if (workplacesListView.Columns[1].Width < 200)
                workplacesListView.Columns[1].Width = 200;

            workplacesListView.Columns[2].Width = -1;

            if (workplacesListView.Columns[2].Width < 300)
                workplacesListView.Columns[2].Width = 300;
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadWorkPlacesAsync();
        }

        private async void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadWorkPlacesAsync();
        }

        private async void previousPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadWorkPlacesAsync();
        }

        private async void nextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadWorkPlacesAsync();
        }

        private async void WorkPlacesScreen_Load(object sender, EventArgs e)
        {
            await LoadWorkPlacesAsync();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ScreenLoading.SetScreenContent(default);
            ScreenLoading.LoadScreen(32);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (workplacesListView.SelectedIndices.Count > 0)
            {
                foreach (var workPlace in _workPlaces)
                {
                    if (workPlace.Label == workplacesListView.SelectedItems[0].SubItems[1].Text && workPlace.Location == workplacesListView.SelectedItems[0].SubItems[2].Text)
                    {
                        ScreenLoading.SetScreenContent(workPlace.ID);
                        ScreenLoading.LoadScreen(32);
                        return;
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            if (workplacesListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var workPlace in _workPlaces)
                {
                    if (workPlace.Label == workplacesListView.SelectedItems[0].SubItems[1].Text && workPlace.Location == workplacesListView.SelectedItems[0].SubItems[2].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveWorkPlaceAsync(workPlace.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            _currentPageNumber = 1;
                            await LoadWorkPlacesAsync();
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
