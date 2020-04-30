using Desktop.Models;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Desktop
{
    public partial class LoginForm : Form
    {
        private bool _loggingIn = false;
        private MainForm _mainForm;
        private ToolTip _toolTip = new ToolTip();

        public LoginForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            loginTextBox.Text = "admin@test.com";
            passwordTextBox.Text = "Baklazan666";
            _toolTip.SetToolTip(logInButton, "Log in");
            _toolTip.SetToolTip(minimizeButton, "Minimize");
            _toolTip.SetToolTip(closeButton, "Close");
            _toolTip.SetToolTip(showCheckBox, "Show password");
        }

        #region DragForm
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam); //Drag form by top panel
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        #endregion

        #region CreateRoundCorner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        #endregion

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (!_loggingIn)
                this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void logInButton_ClickAsync(object sender, System.EventArgs e)
        {
            errorLabel.Text = String.Empty;

            if (loginTextBox.Text == "")
            {
                errorLabel.Text += "Login is empty";
                errorLabel.Visible = true;
                return;
            }
            else if (passwordTextBox.Text == "")
            {
                errorLabel.Text += "Password is empty";
                errorLabel.Visible = true;
                return;
            }

            loadingPictureBox.Visible = true;
            logInButton.Enabled = false;
            _loggingIn = true;

            var response = await ApiHelper.Instance.LoginUser(loginTextBox.Text, passwordTextBox.Text);

            if (response.Success)
            {
                CurrentUser.User.Token = response.Token;
                CurrentUser.User.Email = loginTextBox.Text;
                CurrentUser.User.Role = response.UserRole;

                this.Hide();
                _mainForm = new MainForm();
                _mainForm.FilterOutUnauthorizedMenus();
                _mainForm.ShowDialog();
                this.Close();

                return;
            }

            loadingPictureBox.Visible = false;
            logInButton.Enabled = true;
            _loggingIn = false;

            foreach (var error in response.Errors)
            {
                errorLabel.Text += error + Environment.NewLine;
                errorLabel.Visible = true;
            }
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void showCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCheckBox.Checked == true)
                passwordTextBox.PasswordChar = '\0';
            else
                passwordTextBox.PasswordChar = '*';
        }

    }
}
