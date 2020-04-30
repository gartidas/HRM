using Desktop.Forms;
using Desktop.Utils;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    public partial class ChangePasswordScreen : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();

        public ChangePasswordScreen(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;
        }

        private async void ChangePasswordScreen_Load(object sender, System.EventArgs e)
        {
            if (_id == default)
                return;

            await LoadEmailLabelAsync();
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

        private async void resetButton_Click(object sender, System.EventArgs e)
        {
            if (passwordTextBox.Text == "")
            {
                _toolTip.Show("New password is empty", passwordTextBox);
                return;
            }

            var response = await ApiHelper.Instance.ResetPasswordOfSelectedUserAsync(_id, passwordTextBox.Text);

            errorLabel.Text = "";

            if (response.Success)
            {
                passwordTextBox.Text = "";
                errorLabel.Text = "Password successfuly changed";
            }
            else
            {
                foreach (var error in response.Errors)
                {
                    errorLabel.Text += error;
                }
            }

            errorLabel.Visible = true;
        }

        private void doneButton_Click(object sender, System.EventArgs e)
        {
            ContentLoading.LoadScreen(MainFormStateSingleton.Instance.LastLoadedScreen);
        }
    }
}
