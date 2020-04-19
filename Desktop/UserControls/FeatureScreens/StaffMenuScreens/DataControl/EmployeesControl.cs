﻿using Desktop.Forms;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class EmployeesControl : UserControl
    {
        private string _id;
        private List<EmployeeWorkPlaceData> _workplaces = new List<EmployeeWorkPlaceData>();
        private ToolTip _toolTip = new ToolTip();

        public EmployeesControl(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;

            foreach (var status in Enum.GetValues(typeof(FamilyStatus)))
            {
                var str = (string.Concat(status.ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                familyStatusComboBox.Items.Add(str[0] + str.Substring(1).ToLower());
            }

            foreach (var role in Enum.GetValues(typeof(Role)))
            {
                if (role.ToString() != Role.SysAdmin.ToString())
                {
                    roleComboBox.Items.Add(role);
                }
            }

            birthDateMonthCalendar.MaxDate = DateTime.Now.Date.AddDays(-1);
        }

        private async void EmployeesControl_Load(object sender, EventArgs e)
        {
            await LoadWorkplacesComboBox();

            if (_id != default)
            {
                await LoadData();
            }
        }

        private async Task LoadWorkplacesComboBox()
        {
            var response = await ApiHelper.Instance.GetAllWorkPlacesAsync();

            for (int i = 1; i <= response.Pages; i++)
            {
                _workplaces.AddRange((await ApiHelper.Instance.GetAllWorkPlacesAsync(i)).Content);
            }

            foreach (var workplace in _workplaces)
            {
                workplaceComboBox.Items.Add($"{workplace.Label} at {workplace.Location}");
            }
        }

        private async Task LoadData()
        {
            var result = await ApiHelper.Instance.GetSelectedEmployeeDataAsync(_id);

            if (result != null)
            {
                LoadComponents(result);
            }
        }

        private void LoadComponents(Employee employee)
        {
            #region TextBoxes
            titleTextBox.Text = employee.Data.Title;
            nameTextBox.Text = employee.Data.Name;
            surnameTextBox.Text = employee.Data.Surname;
            emailAddressTextBox.Text = employee.Data.EmailAddress;
            phoneNumberTextBox.Text = employee.Data.PhoneNumber;
            specialtyTextBox.Text = employee.Data.Specialty;
            addressTextBox.Text = employee.Data.AddressOfPermanentResidence;
            birthCertificateNumberTextBox.Text = employee.Data.BirthCertificateNumber;
            birthPlaceTextBox.Text = employee.Data.BirthPlace;
            citizenshipTextBox.Text = employee.Data.Citizenship;
            salaryTextBox.Text = employee.Data.Salary.ToString();
            numberOfVacationDaysTextBox.Text = employee.Data.NumberOfVacationDays.ToString();
            numberOfChildrenTextBox.Text = employee.Data.NumberOfChildren.ToString();
            drivingLicenceNumberTextBox.Text = employee.Data.DrivingLicenceNumber;
            idCardNumberTextBox.Text = employee.Data.IdCardNumber;
            nameOfTheBankTextBox.Text = employee.Data.NameOfTheBank;
            accountNumberTextBox.Text = employee.Data.AccountNumber;
            healthInsuranceCompanyTextBox.Text = employee.Data.HealthInsuranceCompany;
            #endregion

            #region ComboBoxes
            foreach (var item in workplaceComboBox.Items)
            {
                if (item.ToString() == $"{employee.WorkPlace.Label} at {employee.WorkPlace.Location}")
                {
                    workplaceComboBox.SelectedItem = item;
                }
            }

            foreach (var item in familyStatusComboBox.Items)
            {
                if (item.ToString() == employee.Data.FamilyStatus.ToString())
                {
                    familyStatusComboBox.SelectedItem = item;
                }
            }

            foreach (var item in roleComboBox.Items)
            {
                if (item.ToString() == employee.Data.Role.ToString())
                {
                    roleComboBox.SelectedItem = item;
                }
            }
            #endregion

            if (employee.Data.Gender)
                female_RB.Checked = true;
            else
                male_RB.Checked = true;

            birthDateMonthCalendar.SelectionStart = employee.Data.BirthDate;
        }

        private void manageFilesButton_Click(object sender, EventArgs e)
        {
            LoadScreen(14);
        }

        private void LoadScreen(int screenNumber)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden)
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;

                if (MainFormStateSingleton.Instance.ScreenOpened == screenNumber)
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;
                    MainFormStateSingleton.Instance.ScreensChanging = true;
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                }
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (_id == default)
            {
                return;
            }

            foreach (var control in mainPanel.Controls)
            {
                if (control is TextBox && ((TextBox)control).Text == "" && !(control as TextBox).Equals(phoneNumberTextBox))
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty.", (TextBox)control);
                    return;
                }
            }

            if (familyStatusComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected.", familyStatusComboBox);
                return;
            }

            if (workplaceComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected.", workplaceComboBox);
                return;
            }

            if (roleComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected.", roleComboBox);
                return;
            }

            if ((!double.TryParse(salaryTextBox.Text, out double salaryResult)) || salaryResult < 0)
            {
                _toolTip.Show("Number in wrong format.", salaryTextBox);
                return;
            }

            if ((!int.TryParse(numberOfVacationDaysTextBox.Text, out int vacationsResult)) || vacationsResult < 0)
            {
                _toolTip.Show("Number in wrong format.", numberOfVacationDaysTextBox);
                return;
            }

            if ((!int.TryParse(numberOfChildrenTextBox.Text, out int childrenResult)) || childrenResult < 0)
            {
                _toolTip.Show("Number in wrong format.", numberOfChildrenTextBox);
                return;
            }

            var strAr = workplaceComboBox.SelectedItem.ToString().Split(' ');
            string workPlaceId = "";

            foreach (var workPlace in _workplaces)
            {
                if (workPlace.Label == strAr[0] && workPlace.Location == strAr[2])
                {
                    workPlaceId = workPlace.ID;
                }
            }

            var result = await ApiHelper.Instance.EditEmployeeAsync(_id, titleTextBox.Text, nameTextBox.Text, surnameTextBox.Text, emailAddressTextBox.Text, phoneNumberTextBox.Text, specialtyTextBox.Text, addressTextBox.Text, birthCertificateNumberTextBox.Text, birthDateMonthCalendar.SelectionStart, birthPlaceTextBox.Text, citizenshipTextBox.Text, female_RB.Checked, double.Parse(salaryTextBox.Text), int.Parse(numberOfVacationDaysTextBox.Text), workPlaceId, (Role)Enum.Parse(typeof(Role), roleComboBox.SelectedItem.ToString()), idCardNumberTextBox.Text, drivingLicenceNumberTextBox.Text, healthInsuranceCompanyTextBox.Text, int.Parse(numberOfChildrenTextBox.Text), (FamilyStatus)Enum.Parse(typeof(FamilyStatus), familyStatusComboBox.SelectedItem.ToString()), nameOfTheBankTextBox.Text, accountNumberTextBox.Text);

            errorLabel.Text = "";

            if (result.Success)
            {
                errorLabel.Visible = false;
                LoadScreen(18);
                return;
            }

            foreach (var error in result.Errors)
            {
                errorLabel.Text += error;
            }
            errorLabel.Visible = true;
        }
    }
}
