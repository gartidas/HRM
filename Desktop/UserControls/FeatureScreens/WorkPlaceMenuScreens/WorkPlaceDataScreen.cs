using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    public partial class WorkPlaceDataScreen : UserControl
    {

        private string _id;
        private int _currentPageNumber = 1;
        private int _numberOfPages;


        public WorkPlaceDataScreen()
        {
            InitializeComponent();
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadEmployeesAsync();
        }

        private async void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadEmployeesAsync();
        }

        private async void previousPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadEmployeesAsync();
        }

        private async void nextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadEmployeesAsync();
        }

        private async Task LoadWorkPlaceDataAsync()
        {
            var response = await ApiHelper.Instance.GetEmployeeDataAsync();

            if (response != null)
            {
                _id = response.WorkPlace.ID;
                labelLabel.Text = response.WorkPlace.Label;
                locationLabel.Text = response.WorkPlace.Location;
                labelLabel.Visible = true;
                locationLabel.Visible = true;
                await LoadEmployeesAsync();
            }
        }

        private async void WorkPlaceDataScreen_Load(object sender, EventArgs e)
        {
            await LoadWorkPlaceDataAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            GenericGetAllResponse<Employee> response = null;

            if (emailFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, emailFilter: filterTextBox.Text, workPlaceIdFilter: _id);
            else if (specialtyFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, specialtyFilter: filterTextBox.Text, workPlaceIdFilter: _id);
            else if (surnameFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, surnameFilter: filterTextBox.Text, workPlaceIdFilter: _id);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            LoadListView(response.Content);
        }

        private void LoadListView(IEnumerable<Employee> employees)
        {
            workPlaceEmployeesListView.Clear();

            workPlaceEmployeesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            workPlaceEmployeesListView.Columns.Add(new ColumnHeader { Name = "Title", TextAlign = HorizontalAlignment.Center, Text = "Title" });
            workPlaceEmployeesListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            workPlaceEmployeesListView.Columns.Add(new ColumnHeader { Name = "Specialty", TextAlign = HorizontalAlignment.Center, Text = "Specialty" });
            workPlaceEmployeesListView.Columns.Add(new ColumnHeader { Name = "Birthday", TextAlign = HorizontalAlignment.Center, Text = "Birthday" });

            workPlaceEmployeesListView.View = View.Details;

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Email: {employee.Data.EmailAddress}
Phone: {employee.Data.PhoneNumber}"
                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.Title));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{employee.Data.Name} {employee.Data.Surname}"));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.Specialty));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{employee.Data.BirthDate.Day}.{employee.Data.BirthDate.Month}.{employee.Data.BirthDate.Year}"));

                    workPlaceEmployeesListView.Items.Add(item);
                }
            }

            workPlaceEmployeesListView.Columns[1].Width = -1;

            if (workPlaceEmployeesListView.Columns[1].Width < 100)
                workPlaceEmployeesListView.Columns[1].Width = 100;

            workPlaceEmployeesListView.Columns[2].Width = -1;

            if (workPlaceEmployeesListView.Columns[2].Width < 100)
                workPlaceEmployeesListView.Columns[2].Width = 100;

            workPlaceEmployeesListView.Columns[3].Width = -1;

            if (workPlaceEmployeesListView.Columns[3].Width < 200)
                workPlaceEmployeesListView.Columns[3].Width = 200;

            workPlaceEmployeesListView.Columns[4].Width = -1;

            if (workPlaceEmployeesListView.Columns[4].Width < 100)
                workPlaceEmployeesListView.Columns[4].Width = 200;
        }
    }
}
