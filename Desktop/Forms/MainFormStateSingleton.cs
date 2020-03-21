using Desktop.UserControls.FeatureScreens;
using Desktop.UserControls.Menus;
using System;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public class MainFormStateSingleton
    {
        private static MainFormStateSingleton _instance;

        public static MainFormStateSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainFormStateSingleton();
                return _instance;
            }
        }

        #region ScreenState
        public Timer screenTimer = new Timer();
        public bool screensChanging = false;
        public bool screenHidden = true;
        public bool screenMoving = false;
        public int screenOpened;
        public int screenWidth;
        public Panel screenPanel;
        public PersonalDataScreen personalDataScreen;
        public ChangePasswordScreen changePasswordScreen;
        #endregion

        #region MenuState
        public Timer menuTimer = new Timer();
        public bool menusChanging = false;
        public bool menuHidden = true;
        public bool menuMoving = false;
        public int menuOpened;
        public int menuWidth;
        public bool menuClosing = false;
        public Panel menuPanel;
        public PersonalMenu personalMenu;
        public WorkPlaceMenu workPlaceMenu;
        public StaffMenu staffMenu;
        #endregion

        public MainFormStateSingleton()
        {
            menuTimer.Interval = 30;
            screenTimer.Interval = 10;
            menuTimer.Tick += new EventHandler(menuTimer_Tick);
            screenTimer.Tick += new EventHandler(screenTimer_Tick);
        }

        private void menuTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            menuMoving = true;

            if (menuHidden)
            {
                switch (menuOpened)
                {
                    case 1:
                        menuPanel.Controls.Add(personalMenu);
                        break;
                    case 2:
                        menuPanel.Controls.Add(workPlaceMenu);
                        break;
                    case 3:
                        menuPanel.Controls.Add(staffMenu);
                        break;
                    default:
                        break;
                }

                if (menuPanel.Width >= menuWidth)
                {
                    menuTimer.Stop();
                    menuHidden = false;
                    menuMoving = false;
                    return;
                }

                menuPanel.Width += 10;
            }
            else
            {
                if (menuPanel.Width <= 0)
                {
                    menuTimer.Stop();
                    menuHidden = true;
                    menuMoving = false;
                    menuPanel.Controls.Clear();

                    if (menusChanging)
                    {
                        menusChanging = false;
                        menuTimer.Start();
                    }
                    return;
                }

                menuPanel.Width -= 10;
            }
        }

        private void screenTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            screenMoving = true;

            if (screenHidden)
            {
                switch (screenOpened)
                {
                    case 1:
                        screenPanel.Controls.Add(personalDataScreen);
                        break;
                    case 2:
                        screenPanel.Controls.Add(changePasswordScreen);
                        break;
                    case 3:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 4:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 5:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 6:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    case 7:
                        //_mainPanel.Controls.Add(_changePasswordScreen);
                        break;
                    default:
                        break;
                }
                screenPanel.Width += 10;

                if (screenPanel.Width >= screenWidth)
                {
                    screenTimer.Stop();
                    screensChanging = false;
                    screenHidden = false;
                    screenMoving = false;
                    return;
                }
            }
            else
            {
                screenPanel.Width -= 10;

                if (screenPanel.Width <= 0)
                {
                    screenTimer.Stop();
                    screenHidden = true;
                    screenMoving = false;
                    screenPanel.Controls.Clear();

                    if (screensChanging)
                    {
                        screenTimer.Start();
                    }
                    if (menuClosing)
                    {
                        menuClosing = false;
                        menuTimer.Start();
                    }
                    return;
                }
            }
        }
    }
}
