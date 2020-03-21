using Desktop.Forms;
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
        private PersonalMenu _personalMenu;
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
            timeTimer.Start();
            timeLabel.Visible = true;
            MainFormStateSingleton.Instance.menuPanel = subMenuPanel;
            MainFormStateSingleton.Instance.screenPanel = mainPanel;
            MainFormStateSingleton.Instance.menuWidth = subMenuPanel.Width;
            subMenuPanel.Width = 0;
            MainFormStateSingleton.Instance.screenWidth = mainPanel.Width;
            mainPanel.Width = 0;
            _personalMenu = new PersonalMenu(CurrentUser.User.Email, CurrentUser.User.Role.ToString());
            MainFormStateSingleton.Instance.personalMenu = _personalMenu;
            MainFormStateSingleton.Instance.staffMenu = _staffMenu;
            MainFormStateSingleton.Instance.workPlaceMenu = _workPlaceMenu;
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
            if (!MainFormStateSingleton.Instance.screenMoving && !MainFormStateSingleton.Instance.menuMoving)
            {
                DisposeResources();
                this.Close();
            }
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
            if (!MainFormStateSingleton.Instance.screenMoving && !MainFormStateSingleton.Instance.menuMoving)
            {
                subMenuPanel.Controls.Clear();
                mainPanel.Controls.Clear();
                this.Hide();
                ApiHelper.Instance.LogoutUser();
                _loginForm = new LoginForm();
                _loginForm.ShowDialog();
                this.Close();
            }
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
            LoadMenu(1);
        }

        private void workPlaceMenuButton_Click(object sender, EventArgs e)
        {
            LoadMenu(2);
        }

        private void staffMenuButton_Click(object sender, EventArgs e)
        {
            LoadMenu(3);
        }

        private void LoadMenu(int menuNumber)
        {
            if (!MainFormStateSingleton.Instance.screenMoving && !MainFormStateSingleton.Instance.menuMoving)
            {
                if (MainFormStateSingleton.Instance.screenHidden == true)
                {
                    if (MainFormStateSingleton.Instance.menuHidden)
                        MainFormStateSingleton.Instance.menuOpened = menuNumber;

                    if (MainFormStateSingleton.Instance.menuOpened == menuNumber)
                        MainFormStateSingleton.Instance.menuTimer.Start();
                    else
                    {
                        MainFormStateSingleton.Instance.menuOpened = menuNumber;
                        MainFormStateSingleton.Instance.menusChanging = true;
                        MainFormStateSingleton.Instance.menuTimer.Start();
                    }
                }
                else
                {
                    if (MainFormStateSingleton.Instance.menuOpened == menuNumber)
                    {
                        MainFormStateSingleton.Instance.menuClosing = true;
                        MainFormStateSingleton.Instance.screenTimer.Start();
                    }
                    else
                    {
                        MainFormStateSingleton.Instance.menuClosing = true;
                        MainFormStateSingleton.Instance.menuOpened = menuNumber;
                        MainFormStateSingleton.Instance.menusChanging = true;
                        MainFormStateSingleton.Instance.screenTimer.Start();
                    }
                }
            }
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = (DateTime.Now).ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void DisposeResources()
        {
            MainFormStateSingleton.Instance.menuTimer.Dispose();
            MainFormStateSingleton.Instance.menuTimer = null;
            MainFormStateSingleton.Instance.screenTimer.Dispose();
            MainFormStateSingleton.Instance.screenTimer = null;
            timeTimer.Stop();
            timeTimer.Dispose();
            timeTimer = null;
        }
    }
}
