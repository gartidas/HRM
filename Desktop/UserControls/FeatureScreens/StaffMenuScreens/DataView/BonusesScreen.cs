using Desktop.Forms;
using Desktop.Models;
using Desktop.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class BonusesScreen : UserControl
    {
        private string _id;
        private List<Bonus> _bonuses = new List<Bonus>();

        public BonusesScreen(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void BonusesScreen_Load(object sender, System.EventArgs e)
        {
            if (_id == default)
                return;

            await LoadDataAsync();
            await LoadEmailLabelAsync();
        }

        private async Task LoadDataAsync()
        {
            bonusesListView.Clear();

            var column1 = new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" };
            var column2 = new ColumnHeader { Name = "Date", TextAlign = HorizontalAlignment.Center, Text = "Date" };
            var column3 = new ColumnHeader { Name = "Value", TextAlign = HorizontalAlignment.Center, Text = "Value" };
            var column4 = new ColumnHeader { Name = "Reason", TextAlign = HorizontalAlignment.Center, Text = "Reason" };

            bonusesListView.Columns.Add(column1);
            bonusesListView.Columns.Add(column2);
            bonusesListView.Columns.Add(column3);
            bonusesListView.Columns.Add(column4);

            bonusesListView.View = View.Details;

            var response = await ApiHelper.Instance.GetBonusesOfSelectedEmployeeAsync(_id);

            if (response != null)
            {
                _bonuses = response.ToList();

                foreach (var bonus in response)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Name: {bonus.HR_Worker.Name}
Email: {bonus.HR_Worker.Email}"
                    };
                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.GrantedDate.ToString("dd.MM.yyyy")));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.Value.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.Description.ToString()));

                    bonusesListView.Items.Add(item);
                }
            }

            bonusesListView.Columns[1].Width = -1;

            if (bonusesListView.Columns[1].Width < 100)
                bonusesListView.Columns[1].Width = 100;

            bonusesListView.Columns[2].Width = -1;

            if (bonusesListView.Columns[2].Width < 150)
                bonusesListView.Columns[2].Width = 150;

            bonusesListView.Columns[3].Width = -1;

            if (bonusesListView.Columns[3].Width < 200)
                bonusesListView.Columns[3].Width = 200;
        }

        private async Task LoadEmailLabelAsync()
        {
            var result = await ApiHelper.Instance.GetSelectedEmployeeAsync(_id);

            if (result != null)
            {
                emailLabel.Text = result.Data.EmailAddress;
                emailLabel.Visible = true;
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.BonusesControl);
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (bonusesListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var bonus in _bonuses)
                {
                    if (bonus.GrantedDate.ToString("dd.MM.yyyy") == bonusesListView.SelectedItems[0].SubItems[1].Text && bonus.Value.ToString() == bonusesListView.SelectedItems[0].SubItems[2].Text && bonus.Description == bonusesListView.SelectedItems[0].SubItems[3].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveBonusAsync(bonus.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            await LoadDataAsync();
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

        private void doneButton_Click(object sender, System.EventArgs e)
        {
            ContentLoading.LoadScreen(MainFormStateSingleton.Instance.LastLoadedScreen);
        }
    }
}
