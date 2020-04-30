using Desktop.Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView
{
    public partial class FormerEmployeeLookUpScreen : UserControl
    {
        private string _id;
        private string _toolTipText;

        public FormerEmployeeLookUpScreen(string id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void FormerEmployeeLookUpScreen_Load(object sender, System.EventArgs e)
        {
            await LoadFormerEmployeeAsync();
        }

        private async Task LoadFormerEmployeeAsync()
        {
            var response = await ApiHelper.Instance.GetSelectedFormerEmployeeAsync(_id);

            if (response != null)
                LoadLabels(response);
        }

        private void LoadLabels(FormerEmployee formerEmployee)
        {
            titleLabel.Text = formerEmployee.Title;
            nameLabel.Text = formerEmployee.Name;
            surnameLabel.Text = formerEmployee.Surname;
            emailLabel.Text = formerEmployee.Email;
            phoneLabel.Text = formerEmployee.PhoneNumber;
            specialtyLabel.Text = formerEmployee.Specialty;
            birthdateLabel.Text = formerEmployee.BirthDate.ToString("dd.MM.yyyy");
            BCRLabel.Text = formerEmployee.BirthCertificateNumber;
            birthplaceLabel.Text = formerEmployee.BirthPlace;
            citizenshipLabel.Text = formerEmployee.Citizenship;
            salaryLabel.Text = formerEmployee.Salary.ToString();
            numberofvacationdaysLabel.Text = formerEmployee.NumberOfVacationDays.ToString();
            addressLabel.Text = formerEmployee.AddressOfPermanentResidence;
            genderLabel.Text = formerEmployee.Gender ? "Female" : "Male";

            _toolTipText = $@"Terminated by: {formerEmployee.HR_Worker.Email}
Terminated on: {formerEmployee.TerminationDate}
Termination reason: {formerEmployee.TerminationReason}";

            foreach (var control in mainPanel.Controls)
            {
                if (control is Label)
                    ((Label)control).Visible = true;
            }
        }

        private void terminatedLabel_MouseEnter(object sender, System.EventArgs e)
        {
            toolTip.Show(_toolTipText, terminatedLabel, 1000000);
        }

        private void terminatedLabel_MouseLeave(object sender, System.EventArgs e)
        {
            toolTip.Hide(terminatedLabel);
        }

        private void manageFilesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.DocumentationScreenFormerEmployees);
        }
    }
}
