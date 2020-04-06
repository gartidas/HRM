using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    public partial class PersonalDataScreen : UserControl
    {
        public PersonalDataScreen()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
        {
            var response = await ApiHelper.Instance.GetEmployeeDataAsync();

            if (response != null)
            {
                #region Workplace
                if (response.WorkPlace != null)
                {
                    workplaceLabelLabel.Text = response.WorkPlace.Label;
                    workplaceLocationLabel.Text = response.WorkPlace.Location;
                    workplaceLabelLabel.Visible = true;
                    workplaceLocationLabel.Visible = true;
                }
                #endregion

                #region PersonalData
                titleLabel.Text = response.Data.Title;
                nameLabel.Text = response.Data.Name;
                surnameLabel.Text = response.Data.Surname;
                phoneLabel.Text = response.Data.PhoneNumber;
                birthDateLabel.Text = response.Data.BirthDate.ToString("dd.MM.yyyy");
                bcnLabel.Text = response.Data.BirthCertificateNumber;
                birthPlaceLabel.Text = response.Data.BirthPlace;
                specialtyLabel.Text = response.Data.Specialty;
                addressLabel.Text = response.Data.AddressOfPermanentResidence;
                citizenshipLabel.Text = response.Data.Citizenship;
                genderLabel.Text = response.Data.Gender ? "female" : "male";
                salaryLabel.Text = response.Data.Salary.ToString();
                numberOfVacationsLabel.Text = response.Data.NumberOfVacationDays.ToString();
                numberOfChildrenLabel.Text = response.Data.NumberOfChildren.ToString();
                switch (response.Data.FamilyStatus)
                {
                    case 0:
                        familyStatusLabel.Text = "Single";
                        break;
                    case 1:
                        familyStatusLabel.Text = "Married";
                        break;
                    case 2:
                        familyStatusLabel.Text = "Divorced";
                        break;
                    case 3:
                        familyStatusLabel.Text = "Widowed";
                        break;
                    default:
                        break;
                }
                titleLabel.Visible = true;
                nameLabel.Visible = true;
                surnameLabel.Visible = true;
                phoneLabel.Visible = true;
                birthDateLabel.Visible = true;
                bcnLabel.Visible = true;
                birthPlaceLabel.Visible = true;
                specialtyLabel.Visible = true;
                addressLabel.Visible = true;
                citizenshipLabel.Visible = true;
                genderLabel.Visible = true;
                salaryLabel.Visible = true;
                numberOfVacationsLabel.Visible = true;
                numberOfChildrenLabel.Visible = true;
                familyStatusLabel.Visible = true;
                #endregion

                #region SensitiveData
                idCardNumberLabel.Text = response.Data.IdCardNumber;
                drivingLicenceLabel.Text = response.Data.DrivingLicenceNumber;
                healthInsuranceLabel.Text = response.Data.HealthInsuranceCompany;
                bankLabel.Text = response.Data.NameOfTheBank;
                accountLabel.Text = response.Data.AccountNumber;
                #endregion
            }

        }

        private void showCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (showCheckBox.Checked)
            {
                idCardNumberLabel.Visible = true;
                drivingLicenceLabel.Visible = true;
                healthInsuranceLabel.Visible = true;
                bankLabel.Visible = true;
                accountLabel.Visible = true;
                descriptionLabel1.Visible = true;
                descriptionLabel2.Visible = true;
                descriptionLabel3.Visible = true;
                descriptionLabel4.Visible = true;
                descriptionLabel5.Visible = true;
            }
            else
            {
                idCardNumberLabel.Visible = false;
                drivingLicenceLabel.Visible = false;
                healthInsuranceLabel.Visible = false;
                bankLabel.Visible = false;
                accountLabel.Visible = false;
                descriptionLabel1.Visible = false;
                descriptionLabel2.Visible = false;
                descriptionLabel3.Visible = false;
                descriptionLabel4.Visible = false;
                descriptionLabel5.Visible = false;
            }
        }

        private async void PersonalDataScreen_LoadAsync(object sender, System.EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
