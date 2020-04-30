using Desktop.Models;
using Desktop.Responses;
using System;
using System.Linq;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class CandidatesControl : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();

        public CandidatesControl(string id)
        {
            InitializeComponent();
            _toolTip.IsBalloon = true;
            foreach (var status in Enum.GetValues(typeof(Status)))
            {
                if (status.ToString() != Status.Hired.ToString())
                {
                    var str = (string.Concat(status.ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    statusComboBox.Items.Add(str[0] + str.Substring(1).ToLower());
                }
            }
            _id = id;
        }

        public void LoadData(Candidate candidate)
        {
            titleTextBox.Text = candidate.Title;
            nameTextBox.Text = candidate.Name;
            surnameTextBox.Text = candidate.Surname;
            educationTextBox.Text = candidate.Education;
            specialtyTextBox.Text = candidate.Specialty;

            foreach (var item in statusComboBox.Items)
            {
                if (item.ToString().Replace(" ", string.Empty).ToLower() == candidate.Status.ToString().ToLower())
                    statusComboBox.SelectedItem = item;
            }

            phoneTextBox.Text = candidate.PhoneNumber;
            emailTextBox.Text = candidate.Email;
            addressTextBox.Text = candidate.Address;
            requestedSalaryTextBox.Text = candidate.RequestedSalary.ToString();
            additionalInfoTextBox.Text = candidate.AdditionalInfo;
            EvaluationNumericUpDown.Value = candidate.Evaluation;
        }

        private async void CandidatesControl_Load(object sender, EventArgs e)
        {
            if (_id != default)
            {
                manageFilesButton.Visible = true;
                var result = await ApiHelper.Instance.GetSelectedCandidateAsync(_id);
                if (result != null)
                    LoadData(result);
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox && (control as TextBox).Text == "" && !(control as TextBox).Equals(additionalInfoTextBox) && !(control as TextBox).Equals(phoneTextBox))
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty", (TextBox)control);
                    return;
                }
            }

            if (statusComboBox.SelectedItem == default)
            {
                _toolTip.Show("There is nothing selected", statusComboBox);
                return;
            }

            if (!double.TryParse(requestedSalaryTextBox.Text, out double result))
            {
                _toolTip.Show("Number in wrong format", requestedSalaryTextBox);
                return;
            }


            var strSelItem = statusComboBox.SelectedItem.ToString().Split(' ');
            string status = "";

            for (int i = 0; i < strSelItem.Length; i++)
            {
                status += Char.ToUpper(strSelItem[i][0]) + strSelItem[i].Substring(1);
            }

            Status enumStat = (Status)(Enum.Parse(typeof(Status), status));

            GenericResponse response = null;

            if (_id == default)
                response = await ApiHelper.Instance.AddCandidateAsync(titleTextBox.Text, nameTextBox.Text, surnameTextBox.Text, educationTextBox.Text, specialtyTextBox.Text, phoneTextBox.Text, emailTextBox.Text, addressTextBox.Text, double.Parse(requestedSalaryTextBox.Text), (int)EvaluationNumericUpDown.Value, enumStat, additionalInfoTextBox.Text);
            else
                response = await ApiHelper.Instance.EditCandidateAsync(_id, titleTextBox.Text, nameTextBox.Text, surnameTextBox.Text, educationTextBox.Text, specialtyTextBox.Text, phoneTextBox.Text, emailTextBox.Text, addressTextBox.Text, double.Parse(requestedSalaryTextBox.Text), (int)EvaluationNumericUpDown.Value, enumStat, additionalInfoTextBox.Text);

            if (response.Success)
            {
                LoadScreen(ScreenName.CandidatesScreen);
            }
            else
            {
                errorLabel.Text = "";
                foreach (var error in response.Errors)
                {
                    errorLabel.Text += error;
                }
                errorLabel.Visible = true;
            }
        }

        private void manageFilesButton_Click(object sender, EventArgs e)
        {
            LoadScreen(ScreenName.DocumentationScreenCandidates);
        }
    }
}
