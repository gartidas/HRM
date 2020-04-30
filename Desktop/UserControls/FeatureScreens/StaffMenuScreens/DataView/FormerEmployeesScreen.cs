using Desktop.Forms;
using Desktop.Models;
using Desktop.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class FormerEmployeesScreen : UserControl
    {
        private int _currentPageNumber = 1;
        private int _numberOfPages;
        private IEnumerable<FormerEmployee> _formerEmployees;

        public FormerEmployeesScreen()
        {
            InitializeComponent();
        }

        private async Task LoadFormerEmployeesAsync()
        {
            GenericGetAllResponse<FormerEmployee> response = null;

            if (emailFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllFormerEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, emailFilter: filterTextBox.Text);
            else if (specialtyFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllFormerEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, specialtyFilter: filterTextBox.Text);
            else if (surnameFilterRadioButton.Checked)
                response = await ApiHelper.Instance.GetAllFormerEmployeesAsync(_currentPageNumber, pageSize: (int)pagingNumericUpDown.Value, surnameFilter: filterTextBox.Text);

            _numberOfPages = response.Pages;
            _currentPageNumber = response.PageNumber;
            pagingLabel.Text = $"{response.PageNumber}/{response.Pages}";
            _formerEmployees = response.Content;
            LoadListView(_formerEmployees);
        }

        private void LoadListView(IEnumerable<FormerEmployee> formerEmployees)
        {
            formerEmployeesListView.Clear();

            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Title", TextAlign = HorizontalAlignment.Center, Text = "Title" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Specialty", TextAlign = HorizontalAlignment.Center, Text = "Specialty" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Birthday", TextAlign = HorizontalAlignment.Center, Text = "Birthday" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Address", TextAlign = HorizontalAlignment.Center, Text = "Address" });
            formerEmployeesListView.Columns.Add(new ColumnHeader { Name = "Email", TextAlign = HorizontalAlignment.Center, Text = "Email" });

            formerEmployeesListView.View = View.Details;

            if (formerEmployees != null)
            {
                foreach (var employee in formerEmployees)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Email: {employee.Email}
Phone: {employee.PhoneNumber}"
                    };

                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Title));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{employee.Name} {employee.Surname}"));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Specialty));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{employee.BirthDate.Day}.{employee.BirthDate.Month}.{employee.BirthDate.Year}"));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.AddressOfPermanentResidence));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, employee.Email));

                    formerEmployeesListView.Items.Add(item);
                }
            }

            formerEmployeesListView.Columns[1].Width = -1;

            if (formerEmployeesListView.Columns[1].Width < 100)
                formerEmployeesListView.Columns[1].Width = 100;

            formerEmployeesListView.Columns[2].Width = -1;

            if (formerEmployeesListView.Columns[2].Width < 200)
                formerEmployeesListView.Columns[2].Width = 200;

            formerEmployeesListView.Columns[3].Width = -1;

            if (formerEmployeesListView.Columns[3].Width < 200)
                formerEmployeesListView.Columns[3].Width = 200;

            formerEmployeesListView.Columns[4].Width = -1;

            if (formerEmployeesListView.Columns[4].Width < 200)
                formerEmployeesListView.Columns[4].Width = 200;

            formerEmployeesListView.Columns[5].Width = -1;

            if (formerEmployeesListView.Columns[5].Width < 200)
                formerEmployeesListView.Columns[5].Width = 200;

            formerEmployeesListView.Columns[6].Width = 0;
        }

        private async void pagingNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadFormerEmployeesAsync();
        }

        private async void filterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            _currentPageNumber = 1;
            await LoadFormerEmployeesAsync();
        }

        private async void previousPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber <= 1) return;

            _currentPageNumber--;
            await LoadFormerEmployeesAsync();
        }

        private async void nextPageButton_Click(object sender, System.EventArgs e)
        {
            if (_currentPageNumber >= _numberOfPages) return;

            _currentPageNumber++;
            await LoadFormerEmployeesAsync();
        }

        private async void FormerEmployeesScreen_Load(object sender, System.EventArgs e)
        {
            await LoadFormerEmployeesAsync();
        }

        private void showButton_Click(object sender, System.EventArgs e)
        {
            if (formerEmployeesListView.SelectedIndices.Count > 0)
            {
                foreach (var formerEmployee in _formerEmployees)
                {
                    if (formerEmployee.Email == formerEmployeesListView.SelectedItems[0].SubItems[formerEmployeesListView.SelectedItems[0].SubItems.Count - 1].Text)
                    {
                        SetScreenContent(formerEmployee.ID);
                        LoadScreen(ScreenName.FormerEmployeeLookUpScreen);
                        return;
                    }
                }
            }
        }

        private async void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (formerEmployeesListView.SelectedIndices.Count > 0)
            {
                ConfirmForm confirmForm = new ConfirmForm(MainFormStateSingleton.Instance.MainForm, false);

                if (confirmForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var formerEmployee in _formerEmployees)
                {
                    if (formerEmployee.Email == formerEmployeesListView.SelectedItems[0].SubItems[formerEmployeesListView.SelectedItems[0].SubItems.Count - 1].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveFormerEmployeeAsync(formerEmployee.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            _currentPageNumber = 1;
                            await LoadFormerEmployeesAsync();
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
