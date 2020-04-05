using Desktop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    public partial class WorkPlaceSpecialtiesScreen : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();
        private List<Specialty> _specialties = new List<Specialty>();

        public WorkPlaceSpecialtiesScreen()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
        {
            specialtiesListView.Clear();

            specialtiesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            specialtiesListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            specialtiesListView.Columns.Add(new ColumnHeader { Name = "Count", TextAlign = HorizontalAlignment.Center, Text = "Count" });

            specialtiesListView.View = View.Details;

            var response = await ApiHelper.Instance.GetAllSpecialtiesOfWorkplaceAsync(_id);

            if (response != null)
            {
                _specialties = response.ToList();

                foreach (var specialty in _specialties)
                {
                    var item = new ListViewItem
                    {

                    };
                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, specialty.Name));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, specialty.NumberOfEmployees.ToString()));

                    specialtiesListView.Items.Add(item);
                }
            }

            specialtiesListView.Columns[1].Width = -1;

            if (specialtiesListView.Columns[1].Width < 100)
                specialtiesListView.Columns[1].Width = 100;

            specialtiesListView.Columns[2].Width = -1;

            if (specialtiesListView.Columns[2].Width < 100)
                specialtiesListView.Columns[2].Width = 100;
        }

        private async void addSpecialtyButton_Click(object sender, System.EventArgs e)
        {
            bool found = false;

            if (countTextBox.Text != "" && countTextBox.Text != "")
            {
                if (int.TryParse(countTextBox.Text, out int result))
                {
                    foreach (var specialty in _specialties)
                    {
                        if (specialty.Name.ToLower() == nameTextBox.Text.ToLower())
                            found = true;
                    }
                    if (!found)
                    {
                        var response = await ApiHelper.Instance.AddSpecialtyOfWorkPlaceAsync(_id, nameTextBox.Text, result);
                        if (response.Success)
                        {
                            await LoadDataAsync();
                            countTextBox.Clear();
                            nameTextBox.Clear();
                        }
                    }
                    else
                        _toolTip.Show("Already added", nameTextBox, 3000);
                }
                else
                    _toolTip.Show("Not a number", countTextBox, 3000);
            }
        }

        private async void removeSpecialtyButton_Click(object sender, System.EventArgs e)
        {
            if (specialtiesListView.SelectedItems.Count > 0)
            {
                foreach (var specialty in _specialties)
                {
                    if (specialty.Name == specialtiesListView.SelectedItems[0].SubItems[1].Text)
                    {
                        var response = await ApiHelper.Instance.DeleteSpecialtyOfWorkPlaceAsync(specialty.ID);

                        if (response.Success)
                        {
                            specialtiesListView.SelectedItems.Clear();
                            await LoadDataAsync();
                        }
                    }
                }
            }
        }

        private async void WorkPlaceSpecialtiesScreen_Load(object sender, System.EventArgs e)
        {
            var response = await ApiHelper.Instance.GetEmployeeDataAsync();
            _id = response.WorkPlace.ID;

            await LoadDataAsync();
        }
    }
}
