using Desktop.Forms;
using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class EmployeesScreen : UserControl
    {
        private int _currentPageNumber = 1;
        private int _numberOfPages;
        private IEnumerable<Employee> _employees;

        public EmployeesScreen()
        {
            InitializeComponent();
            if (CurrentUser.User.Role == Role.SysAdmin)
                fireButton.Enabled = false;
        }

        private async Task LoadEmployeesAsync()
        {
            GenericGetAllResponse<Employee> response = null;

            if (emailFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, emailFilter: filterTextBox.Text);
            else if (specialtyFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, specialtyFilter: filterTextBox.Text);
            else if (surnameFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, surnameFilter: filterTextBox.Text);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            _employees = response.Content;
            LoadListView(_employees);
        }

        private void LoadListView(IEnumerable<Employee> employees)
        {
            employeesListView.Clear();

            employeesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Title", TextAlign = HorizontalAlignment.Center, Text = "Title" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Specialty", TextAlign = HorizontalAlignment.Center, Text = "Specialty" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Birthday", TextAlign = HorizontalAlignment.Center, Text = "Birthday" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Address", TextAlign = HorizontalAlignment.Center, Text = "Address" });
            employeesListView.Columns.Add(new ColumnHeader { Name = "Email", TextAlign = HorizontalAlignment.Center, Text = "Email" });

            employeesListView.View = View.Details;

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Email: {employee.Data.EmailAddress}
Role: {employee.Data.Role}
Phone: {employee.Data.PhoneNumber}
WorkPlace: {employee.WorkPlace.Label} at {employee.WorkPlace.Location}"
                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.Title));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{employee.Data.Name} {employee.Data.Surname}"));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.Specialty));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.BirthDate.ToString("dd.MM.yyyy")));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.AddressOfPermanentResidence));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Data.EmailAddress));

                    employeesListView.Items.Add(item);
                }
            }

            employeesListView.Columns[1].Width = -1;

            if (employeesListView.Columns[1].Width < 100)
                employeesListView.Columns[1].Width = 100;

            employeesListView.Columns[2].Width = -1;

            if (employeesListView.Columns[2].Width < 200)
                employeesListView.Columns[2].Width = 200;

            employeesListView.Columns[3].Width = -1;

            if (employeesListView.Columns[3].Width < 200)
                employeesListView.Columns[3].Width = 200;

            employeesListView.Columns[4].Width = -1;

            if (employeesListView.Columns[4].Width < 200)
                employeesListView.Columns[4].Width = 200;

            employeesListView.Columns[5].Width = -1;

            if (employeesListView.Columns[5].Width < 200)
                employeesListView.Columns[5].Width = 200;

            employeesListView.Columns[6].Width = 0;
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadEmployeesAsync();
        }

        private async void filterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadEmployeesAsync();
        }

        private async void previousPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadEmployeesAsync();
        }

        private async void nextPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadEmployeesAsync();
        }

        private async void EmployeesScreen_Load(object sender, System.EventArgs e)
        {
            await LoadEmployeesAsync();
        }

        private async void fireButton_Click(object sender, System.EventArgs e)
        {
            if (employeesListView.SelectedIndices.Count > 0)
            {
                string employeeId = default;

                foreach (var employee in _employees)
                {
                    if (employee.Data.EmailAddress == employeesListView.SelectedItems[0].SubItems[6].Text && CurrentUser.User.Email != employeesListView.SelectedItems[0].SubItems[6].Text)
                        employeeId = employee.ID;
                }

                if (employeeId == default)
                    return;

                string reason = default;
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, true);

                if (confirmForm.ShowDialog() == DialogResult.OK)
                    reason = confirmForm.Input;


                if (reason == default)
                    return;

                var result = await ApiHelper.Instance.FireEmployeeAsync(employeeId, reason, DateTime.Now);

                if (result.Success)
                {
                    errorLabel.Visible = false;
                    _currentPageNumber = 1;
                    await LoadEmployeesAsync();
                    return;
                }

                errorLabel.Text = "";
                foreach (var error in result.Errors)
                {
                    errorLabel.Text += error;
                }
                errorLabel.Visible = true;
            }
        }

        private void editButton_Click(object sender, System.EventArgs e)
        {
            if (employeesListView.SelectedIndices.Count > 0)
            {
                foreach (var employee in _employees)
                {
                    if (employee.Data.EmailAddress == employeesListView.SelectedItems[0].SubItems[6].Text && CurrentUser.User.Email != employeesListView.SelectedItems[0].SubItems[6].Text)
                    {
                        SetScreenContent(employee.ID);
                        LoadScreen(ScreenName.EmployeesControl);
                        return;
                    }
                }
            }
        }
    }
}
