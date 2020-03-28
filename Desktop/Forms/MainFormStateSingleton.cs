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
        public Timer ScreenTimer { get; set; }
        public bool ScreensChanging { get; set; }
        public bool ScreenHidden { get; set; }
        public bool ScreenMoving { get; set; }
        public int ScreenOpened { get; set; }
        public int ScreenWidth { get; set; }
        public Panel ScreenPanel { get; set; }
        private bool _screenLoaded;
        #endregion

        #region MenuState
        public Timer MenuTimer { get; set; }
        public bool MenusChanging { get; set; }
        public bool MenuHidden { get; set; }
        public bool MenuMoving { get; set; }
        public int MenuOpened { get; set; }
        public int MenuWidth { get; set; }
        public bool MenuClosing { get; set; }
        public Panel MenuPanel { get; set; }
        public PersonalMenu PersonalMenu { get; set; }
        public WorkPlaceMenu WorkPlaceMenu { get; set; }
        public StaffMenu StaffMenu { get; set; }
        public MaintenanceMenu MaintenanceMenu { get; set; }
        #endregion

        public MainFormStateSingleton()
        {
            ScreenTimer = new Timer();
            MenuTimer = new Timer();
            MenuTimer.Interval = 10;
            ScreenTimer.Interval = 10;
            MenuTimer.Tick += new EventHandler(menuTimer_Tick);
            ScreenTimer.Tick += new EventHandler(screenTimer_Tick);
            ScreensChanging = false;
            ScreenHidden = true;
            ScreenMoving = false;
            MenusChanging = false;
            MenuHidden = true;
            MenuMoving = false;
            MenuClosing = false;
        }

        private void menuTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            MenuMoving = true;

            if (MenuHidden)
            {
                switch (MenuOpened)
                {
                    case 1:
                        MenuPanel.Controls.Add(PersonalMenu);
                        break;
                    case 2:
                        MenuPanel.Controls.Add(WorkPlaceMenu);
                        break;
                    case 3:
                        MenuPanel.Controls.Add(StaffMenu);
                        break;
                    case 4:
                        MenuPanel.Controls.Add(MaintenanceMenu);
                        break;
                    default:
                        break;
                }

                if (MenuPanel.Width >= MenuWidth)
                {
                    MenuTimer.Stop();
                    MenuHidden = false;
                    MenuMoving = false;
                    return;
                }

                MenuPanel.Width += 10;
            }
            else
            {
                if (MenuPanel.Width <= 0)
                {
                    MenuTimer.Stop();
                    MenuHidden = true;
                    MenuMoving = false;
                    MenuPanel.Controls.Clear();

                    if (MenusChanging)
                    {
                        MenusChanging = false;
                        MenuTimer.Start();
                    }
                    return;
                }

                MenuPanel.Width -= 10;
            }
        }

        private void screenTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            ScreenMoving = true;

            if (ScreenHidden)
            {
                if (!_screenLoaded)
                {
                    switch (ScreenOpened)
                    {
                        case 1:
                            ScreenPanel.Controls.Add(new PersonalDataScreen());
                            break;
                        case 2:
                            ScreenPanel.Controls.Add(new ChangePasswordScreen());
                            break;
                        case 3:
                            ScreenPanel.Controls.Add(new VacationsScreen());
                            break;
                        case 4:
                            ScreenPanel.Controls.Add(new CorporateEventsScreen());
                            break;
                        case 5:
                            ScreenPanel.Controls.Add(new EvaluationsScreen());
                            break;
                        case 6:
                            ScreenPanel.Controls.Add(new BonusesScreen());
                            break;
                        case 7:
                            ScreenPanel.Controls.Add(new EquipmentScreen());
                            break;
                        case 8:
                            //ScreenPanel.Controls.Add();
                            break;
                        case 9:
                            //ScreenPanel.Controls.Add();
                            break;
                        case 10:
                            //ScreenPanel.Controls.Add();
                            break;
                        default:
                            break;
                    }
                    _screenLoaded = true;
                }
                ScreenPanel.Width += 20;

                if (ScreenPanel.Width >= ScreenWidth)
                {
                    ScreenTimer.Stop();
                    ScreensChanging = false;
                    ScreenHidden = false;
                    ScreenMoving = false;
                    return;
                }
            }
            else
            {
                ScreenPanel.Width -= 20;

                if (ScreenPanel.Width <= 0)
                {
                    ScreenTimer.Stop();
                    ScreenHidden = true;
                    ScreenMoving = false;
                    ScreenPanel.Controls.Clear();

                    if (ScreensChanging)
                    {
                        ScreenTimer.Start();
                    }
                    if (MenuClosing)
                    {
                        MenuClosing = false;
                        MenuTimer.Start();
                    }
                    _screenLoaded = false;
                    return;
                }
            }
        }
    }
}
