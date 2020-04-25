using System;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    public partial class PersonalChangePasswordScreen : UserControl
    {
        public PersonalChangePasswordScreen()
        {
            InitializeComponent();
        }

        private void showCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCheckBox.Checked == true)
            {
                currentPasswordTextBox.PasswordChar = '\0';
                newPasswordTextBox.PasswordChar = '\0';
                confirmPasswordTextBox.PasswordChar = '\0';
            }

            else
            {
                currentPasswordTextBox.PasswordChar = '*';
                newPasswordTextBox.PasswordChar = '*';
                confirmPasswordTextBox.PasswordChar = '*';
            }
        }

        private async void changePasswordButton_ClickAsync(object sender, EventArgs e)
        {
            if (newPasswordTextBox.Text.Length > 0 || confirmPasswordTextBox.Text.Length > 0 || currentPasswordTextBox.Text.Length > 0)
            {
                errorLabel.Text = String.Empty;

                if (currentPasswordTextBox.Text == "")
                {
                    errorLabel.Text += "Old password is empty";
                    return;
                }
                else if (newPasswordTextBox.Text == "")
                {
                    errorLabel.Text += "New password is empty";
                    return;
                }
                else if (confirmPasswordTextBox.Text == "")
                {
                    errorLabel.Text += "Confirm password is empty";
                    return;
                }
                else if (newPasswordTextBox.Text != confirmPasswordTextBox.Text)
                {
                    errorLabel.Text += "New password and confirm password does not match";
                    return;
                }

                var response = await ApiHelper.Instance.ChangePasswordAsync(currentPasswordTextBox.Text, newPasswordTextBox.Text);

                if (response.Success)
                {
                    errorLabel.Text = String.Empty;
                    errorLabel.Text += "Password changed succesfully";
                    currentPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                    confirmPasswordTextBox.Text = "";
                    return;
                }

                foreach (var error in response.Errors)
                {
                    errorLabel.Text += error + Environment.NewLine;
                }
            }
        }

        private void errorLabel_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = true;
        }
    }
}
