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
        private WorkPlaceMenu _workPlaceMenu = new WorkPlaceMenu();
        private StaffMenu _staffMenu = new StaffMenu();
        private MaintenanceMenu _maintenanceMenu = new MaintenanceMenu();
        private int _timeLoaded = 0;

        public int TimeLoaded
        {
            get { return _timeLoaded; }
            set
            {
                _timeLoaded = value;

                if (_timeLoaded == 1)
                {
                    timeLabel.Visible = true;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            timeTimer.Start();
            _toolTip.SetToolTip(staffMenuButton, "Staff menu");
            _toolTip.SetToolTip(personalMenuButton, "Personal menu");
            _toolTip.SetToolTip(workPlaceMenuButton, "Workplace menu");
            _toolTip.SetToolTip(maintenanceMenuButton, "Maintenance menu");
            _toolTip.SetToolTip(logOutButton, "Log out");
            _toolTip.SetToolTip(minimizeButton, "Minimize");
            _toolTip.SetToolTip(closeButton, "Close");
            MainFormStateSingleton.Instance.MenuPanel = subMenuPanel;
            MainFormStateSingleton.Instance.ScreenPanel = mainPanel;
            MainFormStateSingleton.Instance.MenuWidth = subMenuPanel.Width;
            subMenuPanel.Width = 0;
            MainFormStateSingleton.Instance.ScreenWidth = mainPanel.Width;
            mainPanel.Width = 0;
            _personalMenu = new PersonalMenu(CurrentUser.User.Email, CurrentUser.User.Role.ToString());
            MainFormStateSingleton.Instance.PersonalMenu = _personalMenu;
            MainFormStateSingleton.Instance.WorkPlaceMenu = _workPlaceMenu;
            MainFormStateSingleton.Instance.StaffMenu = _staffMenu;
            MainFormStateSingleton.Instance.MaintenanceMenu = _maintenanceMenu;
            ApiHelper.Instance.LoadingPictureBox = loadingPictureBox;
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
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
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
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
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
            if (CurrentUser.User.Role != Role.HR_Worker)
                staffMenuButton.Enabled = false;

            if (CurrentUser.User.Role != Role.WorkPlaceLeader)
                workPlaceMenuButton.Enabled = false;

            if (CurrentUser.User.Role == Role.SysAdmin)
            {
                maintenanceMenuButton.Visible = true;
                staffMenuButton.Enabled = true;
                workPlaceMenuButton.Enabled = true;
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

        private void maintenanceMenuButton_Click(object sender, EventArgs e)
        {
            LoadMenu(4);
        }

        private void LoadMenu(int menuNumber)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden == true)
                {
                    if (MainFormStateSingleton.Instance.MenuHidden)
                        MainFormStateSingleton.Instance.MenuOpened = menuNumber;

                    if (MainFormStateSingleton.Instance.MenuOpened == menuNumber)
                        MainFormStateSingleton.Instance.MenuTimer.Start();
                    else
                    {
                        MainFormStateSingleton.Instance.MenuOpened = menuNumber;
                        MainFormStateSingleton.Instance.MenusChanging = true;
                        MainFormStateSingleton.Instance.MenuTimer.Start();
                    }
                }
                else
                {
                    if (MainFormStateSingleton.Instance.MenuOpened == menuNumber)
                    {
                        MainFormStateSingleton.Instance.MenuClosing = true;
                        MainFormStateSingleton.Instance.ScreenTimer.Start();
                    }
                    else
                    {
                        MainFormStateSingleton.Instance.MenuClosing = true;
                        MainFormStateSingleton.Instance.MenuOpened = menuNumber;
                        MainFormStateSingleton.Instance.MenusChanging = true;
                        MainFormStateSingleton.Instance.ScreenTimer.Start();
                    }
                }
            }
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = (DateTime.Now).ToString("dd.MM.yyyy HH:mm:ss");
            TimeLoaded++;
        }

        private void DisposeResources()
        {
            MainFormStateSingleton.Instance.MenuTimer.Dispose();
            MainFormStateSingleton.Instance.MenuTimer = null;
            MainFormStateSingleton.Instance.ScreenTimer.Dispose();
            MainFormStateSingleton.Instance.ScreenTimer = null;
            timeTimer.Stop();
            timeTimer.Dispose();
            timeTimer = null;
        }
    }
}
