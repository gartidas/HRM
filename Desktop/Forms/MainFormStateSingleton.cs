using Desktop.UserControls.FeatureScreens;
using Desktop.UserControls.Menus;
using System;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public sealed class MainFormStateSingleton
    {
        private static MainFormStateSingleton instance = null;
        private static readonly object padlock = new object();

        public static MainFormStateSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MainFormStateSingleton();
                    }
                    return instance;
                }
            }
        }

        #region ScreenState
        public static Timer screenTimer = new Timer();
        public static bool screensChanging = false;
        public static bool screenHidden = true;
        public static int screenOpened;
        public static int screenWidth;
        public static Panel screenPanel;
        public static PersonalDataScreen personalDataScreen;
        public static ChangePasswordScreen changePasswordScreen;
        #endregion

        #region MenuState
        public static Timer menuTimer = new Timer();
        public static bool menusChanging = false;
        public static bool menuHidden = true;
        public static int menuOpened;
        public static int menuWidth;
        public static Panel menuPanel;
        public static PersonalMenu personalMenu;
        public static WorkPlaceMenu workPlaceMenu;
        public static StaffMenu staffMenu;
        #endregion

        public MainFormStateSingleton()
        {
            menuTimer.Interval = 30;
            screenTimer.Interval = 10;
            menuTimer.Tick += new EventHandler(menuTimer_Tick);
            screenTimer.Tick += new EventHandler(screenTimer_Tick);
        }

        private static void menuTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
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
                    return;
                }

                menuPanel.Width = menuPanel.Width + 10; //TU
            }
            else
            {
                if (menuPanel.Width <= 0)
                {
                    menuTimer.Stop();
                    menuHidden = true;
                    menuPanel.Controls.Clear();

                    if (menusChanging)
                    {
                        menusChanging = false;
                        menuTimer.Start();
                    }
                    return;
                }

                menuPanel.Width = menuPanel.Width - 10; //TU
            }
        }

        private static void screenTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
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
                screenPanel.Width = screenPanel.Width + 10;

                if (screenPanel.Width >= screenWidth)
                {
                    screenTimer.Stop();
                    screensChanging = false;
                    screenHidden = false;
                    return;
                }
            }
            else
            {
                screenPanel.Width = screenPanel.Width - 10;

                if (screenPanel.Width <= 0)
                {
                    screenTimer.Stop();
                    screenHidden = true;
                    screenPanel.Controls.Clear();

                    if (screensChanging)
                    {
                        screenTimer.Start();
                    }


                    return;
                }
            }
        }
    }
}
