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
        private MainFormStateSingleton _mainFormStateSingleton = new MainFormStateSingleton();

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
            MainFormStateSingleton.menuPanel = subMenuPanel;
            MainFormStateSingleton.screenPanel = mainPanel;
            MainFormStateSingleton.menuWidth = subMenuPanel.Width;
            subMenuPanel.Width = 0;
            MainFormStateSingleton.screenWidth = mainPanel.Width;
            mainPanel.Width = 0;
            _personalMenu = new PersonalMenu(CurrentUser.User.Email, CurrentUser.User.Role.ToString());
            MainFormStateSingleton.personalMenu = _personalMenu;
            MainFormStateSingleton.staffMenu = _staffMenu;
            MainFormStateSingleton.workPlaceMenu = _workPlaceMenu;
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
            if (!MainFormStateSingleton.screenMoving && !MainFormStateSingleton.menuMoving)
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
            if (!MainFormStateSingleton.screenMoving && !MainFormStateSingleton.menuMoving)
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
            if (!MainFormStateSingleton.screenMoving && !MainFormStateSingleton.menuMoving)
            {
                if (MainFormStateSingleton.screenHidden == true)
                {
                    if (MainFormStateSingleton.menuHidden)
                        MainFormStateSingleton.menuOpened = menuNumber;

                    if (MainFormStateSingleton.menuOpened == menuNumber)
                        MainFormStateSingleton.menuTimer.Start();
                    else
                    {
                        MainFormStateSingleton.menuOpened = menuNumber;
                        MainFormStateSingleton.menusChanging = true;
                        MainFormStateSingleton.menuTimer.Start();
                    }
                }
                else
                {
                    if (MainFormStateSingleton.menuOpened == menuNumber)
                    {
                        MainFormStateSingleton.menuClosing = true;
                        MainFormStateSingleton.screenTimer.Start();
                    }
                    else
                    {
                        MainFormStateSingleton.menuClosing = true;
                        MainFormStateSingleton.menuOpened = menuNumber;
                        MainFormStateSingleton.menusChanging = true;
                        MainFormStateSingleton.screenTimer.Start();
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
            MainFormStateSingleton.menuTimer.Dispose();
            MainFormStateSingleton.menuTimer = null;
            MainFormStateSingleton.screenTimer.Dispose();
            MainFormStateSingleton.screenTimer = null;
            timeTimer.Stop();
            timeTimer.Dispose();
            timeTimer = null;
        }
    }
}
