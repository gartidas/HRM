using Desktop.Models;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class HireEmployeeControl : UserControl
    {
        private string _id;
        private List<WorkPlace> _workplaces = new List<WorkPlace>();
        private ToolTip _toolTip = new ToolTip();

        public HireEmployeeControl(string id)
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
            birthDateMonthCalendar.SetDate(DateTime.Now.Date.AddDays(-1));
        }

        private async void HireEmployeeControl_Load(object sender, EventArgs e)
        {
            if (_id != default)
            {
                await LoadCandidateData();
            }
            await LoadWorkplacesComboBox();
        }

        private async Task LoadCandidateData()
        {
            var result = await ApiHelper.Instance.GetSelectedCandidate(_id);

            if (result != null)
            {
                emailAddressLabel.Text = result.Email;
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

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (_id == default)
            {
                return;
            }

            foreach (var control in mainPanel.Controls)
            {
                if (control is TextBox && ((TextBox)control).Text == "")
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty", (TextBox)control);
                    return;
                }
            }

            if (familyStatusComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected", familyStatusComboBox);
                return;
            }

            if (workplaceComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected", workplaceComboBox);
                return;
            }

            if (roleComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected", roleComboBox);
                return;
            }

            if ((!double.TryParse(salaryTextBox.Text, out double salaryResult)) || salaryResult < 0)
            {
                _toolTip.Show("Number in wrong format", salaryTextBox);
                return;
            }

            if ((!int.TryParse(numberOfVacationDaysTextBox.Text, out int vacationsResult)) || vacationsResult < 0)
            {
                _toolTip.Show("Number in wrong format", numberOfVacationDaysTextBox);
                return;
            }

            if ((!int.TryParse(numberOfChildrenTextBox.Text, out int childrenResult)) || childrenResult < 0)
            {
                _toolTip.Show("Number in wrong format", numberOfChildrenTextBox);
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

            strAr = emailAddressLabel.Text.Split('@');

            var password = strAr[0] + "123";

            var result = await ApiHelper.Instance.HireEmployeeAsync(_id, password, birthCertificateNumberTextBox.Text, birthDateMonthCalendar.SelectionStart, birthPlaceTextBox.Text, citizenshipTextBox.Text, female_RB.Checked, double.Parse(salaryTextBox.Text), int.Parse(numberOfVacationDaysTextBox.Text), workPlaceId, (Role)Enum.Parse(typeof(Role), roleComboBox.SelectedItem.ToString()), idCardNumberTextBox.Text, drivingLicenceNumberTextBox.Text, healthInsuranceCompanyTextBox.Text, int.Parse(numberOfChildrenTextBox.Text), (FamilyStatus)Enum.Parse(typeof(FamilyStatus), familyStatusComboBox.SelectedItem.ToString()), nameOfTheBankTextBox.Text, accountNumberTextBox.Text);

            errorLabel.Text = "";

            if (result.Success)
            {
                errorLabel.Visible = false;
                ScreenLoading.LoadScreen(16);
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
