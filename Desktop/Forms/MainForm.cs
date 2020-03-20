using Desktop.Models;
using Desktop.UserControls.Menus;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Desktop
{
    public partial class MainForm : Form
    {
        private LoginForm _loginForm;
        private ToolTip _toolTip = new ToolTip();
        private int _menuWidth;
        private bool _menuHidden;
        private int _menuOpened;
        private bool _menusChanging = false;
        private PersonalMenu _personalMenu = new PersonalMenu();
        private StaffMenu _staffMenu = new StaffMenu();
        private WorkPlaceMenu _workPlaceMenu = new WorkPlaceMenu();

        public MainForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _toolTip.SetToolTip(staffMenuButton, "Staff menu");
            _toolTip.SetToolTip(personalMenuButton, "Personal menu");
            _toolTip.SetToolTip(workPlaceMenuButton, "Workplace menu");
            _toolTip.SetToolTip(logOutButton, "Log out");
            _toolTip.SetToolTip(minimizeButton, "Minimize");
            _toolTip.SetToolTip(closeButton, "Close");
            _menuWidth = subMenuPanel.Width;
            subMenuPanel.Width = 0;
            _menuHidden = true;
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
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApiHelper.Instance.LogoutUser();
            _loginForm = new LoginForm();
            _loginForm.ShowDialog();
            this.Close();
        }

        public void FilterOutUnauthorizedMenus()
        {
            if (CurrentUser.User.Role == Role.WorkPlaceLeader)
                staffMenuButton.Visible = false;

            if (CurrentUser.User.Role == Role.Employee)
            {
                staffMenuButton.Visible = false;
                workPlaceMenuButton.Visible = false;
            }
        }

        private void personalMenuButton_Click(object sender, EventArgs e)
        {
            if (_menuHidden)
                _menuOpened = 1;

            if (_menuOpened == 1)
                loadMenuTimer.Start();
            else
            {
                _menuOpened = 1;
                _menusChanging = true;
                loadMenuTimer.Start();
            }
        }

        private void workPlaceMenuButton_Click(object sender, EventArgs e)
        {
            if (_menuHidden)
                _menuOpened = 2;

            if (_menuOpened == 2)
                loadMenuTimer.Start();
            else
            {
                _menuOpened = 2;
                _menusChanging = true;
                loadMenuTimer.Start();
            }
        }

        private void staffMenuButton_Click(object sender, EventArgs e)
        {
            if (_menuHidden)
                _menuOpened = 3;

            if (_menuOpened == 3)
                loadMenuTimer.Start();
            else
            {
                _menuOpened = 3;
                _menusChanging = true;
                loadMenuTimer.Start();
            }
        }

        private void loadMenuTimer_Tick(object sender, EventArgs e)
        {
            if (_menuHidden)
            {
                switch (_menuOpened)
                {
                    case 1:
                        subMenuPanel.Controls.Add(_personalMenu);
                        break;
                    case 2:
                        subMenuPanel.Controls.Add(_workPlaceMenu);
                        break;
                    case 3:
                        subMenuPanel.Controls.Add(_staffMenu);
                        break;
                    default:
                        break;
                }
                subMenuPanel.Width = subMenuPanel.Width + 10;

                if (subMenuPanel.Width >= _menuWidth)
                {
                    loadMenuTimer.Stop();
                    _menuHidden = false;
                    this.Refresh();
                }
            }
            else
            {
                subMenuPanel.Width = subMenuPanel.Width - 10;

                if (subMenuPanel.Width <= 0)
                {
                    loadMenuTimer.Stop();
                    _menuHidden = true;
                    subMenuPanel.Controls.Clear();
                    this.Refresh();

                    if (_menusChanging)
                    {
                        _menusChanging = false;
                        loadMenuTimer.Start();
                    }
                }
            }
        }
    }
}
