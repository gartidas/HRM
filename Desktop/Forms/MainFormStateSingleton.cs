using Desktop.UserControls.FeatureScreens.PersonalMenuScreens;
using Desktop.UserControls.FeatureScreens.StaffMenuScreens;
using Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl;
using Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataView;
using Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens;
using Desktop.UserControls.FileHandling;
using Desktop.UserControls.Menus;
using System;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

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
        public ScreenName LastLoadedScreen { get; set; }
        public Form MainForm { get; set; }
        public string ScreenContentId { get; set; }
        public Timer ScreenTimer { get; set; }
        public bool ScreensChanging { get; set; }
        public bool ScreenHidden { get; set; }
        public bool ScreenMoving { get; set; }
        public ScreenName ScreenOpened { get; set; }
        public int ScreenWidth { get; set; }
        public Panel ScreenPanel { get; set; }
        private bool _screenLoaded;
        #endregion

        #region MenuState
        public Timer MenuTimer { get; set; }
        public bool MenusChanging { get; set; }
        public bool MenuHidden { get; set; }
        public bool MenuMoving { get; set; }
        public MenuName MenuOpened { get; set; }
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
                    case MenuName.PersonalMenu:
                        MenuPanel.Controls.Add(PersonalMenu);
                        break;
                    case MenuName.WorkPlaceMenu:
                        MenuPanel.Controls.Add(WorkPlaceMenu);
                        break;
                    case MenuName.StaffMenu:
                        MenuPanel.Controls.Add(StaffMenu);
                        break;
                    case MenuName.MaintenanceMenu:
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
                        case ScreenName.PersonalDataScreen:
                            ScreenPanel.Controls.Add(new PersonalDataScreen());
                            break;
                        case ScreenName.PersonalChangePasswordScreen:
                            ScreenPanel.Controls.Add(new PersonalChangePasswordScreen());
                            break;
                        case ScreenName.PersonalVacationsScreen:
                            ScreenPanel.Controls.Add(new PersonalVacationsScreen());
                            break;
                        case ScreenName.PersonalCorporateEventsScreen:
                            ScreenPanel.Controls.Add(new PersonalCorporateEventsScreen());
                            break;
                        case ScreenName.PersonalEvaluationsScreen:
                            ScreenPanel.Controls.Add(new PersonalEvaluationsScreen());
                            break;
                        case ScreenName.PersonalBonusesScreen:
                            ScreenPanel.Controls.Add(new PersonalBonusesScreen());
                            break;
                        case ScreenName.PersonalEquipmentScreen:
                            ScreenPanel.Controls.Add(new PersonalEquipmentScreen());
                            break;
                        case ScreenName.WorkPlaceDataScreen:
                            ScreenPanel.Controls.Add(new WorkPlaceDataScreen());
                            break;
                        case ScreenName.WorkPlaceVacationsScreen:
                            ScreenPanel.Controls.Add(new WorkPlaceVacationsScreen());
                            break;
                        case ScreenName.WorkPlaceCorporateEventsScreen:
                            ScreenPanel.Controls.Add(new WorkPlaceCorporateEventsScreen());
                            break;
                        case ScreenName.WorkPlaceSpecialtiesScreen:
                            ScreenPanel.Controls.Add(new WorkPlaceSpecialtiesScreen());
                            break;
                        case ScreenName.WorkPlaceEvaluationsScreen:
                            ScreenPanel.Controls.Add(new WorkPlaceEvaluationsScreen());
                            break;
                        case ScreenName.DocumentationScreenCandidates:
                            ScreenPanel.Controls.Add(new DocumentationScreen(ScreenContentId, new CandidatesFileHandler()));
                            break;
                        case ScreenName.DocumentationScreenEmployees:
                            ScreenPanel.Controls.Add(new DocumentationScreen(ScreenContentId, new EmployeesFileHandler()));
                            break;
                        case ScreenName.DocumentationScreenFormerEmployees:
                            ScreenPanel.Controls.Add(new DocumentationScreen(ScreenContentId, new FormerEmployeesFileHandler()));
                            break;
                        case ScreenName.CandidatesScreen:
                            ScreenPanel.Controls.Add(new CandidatesScreen());
                            break;
                        case ScreenName.CandidatesControl:
                            LastLoadedScreen = ScreenName.CandidatesControl;
                            ScreenPanel.Controls.Add(new CandidatesControl(ScreenContentId));
                            break;
                        case ScreenName.EmployeesScreen:
                            ScreenPanel.Controls.Add(new EmployeesScreen());
                            break;
                        case ScreenName.EmployeesControl:
                            LastLoadedScreen = ScreenName.EmployeesControl;
                            ScreenPanel.Controls.Add(new EmployeesControl(ScreenContentId));
                            break;
                        case ScreenName.HireEmployeeControl:
                            ScreenPanel.Controls.Add(new HireEmployeeControl(ScreenContentId));
                            break;
                        case ScreenName.FormerEmployeesScreen:
                            ScreenPanel.Controls.Add(new FormerEmployeesScreen());
                            break;
                        case ScreenName.FormerEmployeeLookUpScreen:
                            LastLoadedScreen = ScreenName.FormerEmployeeLookUpScreen;
                            ScreenPanel.Controls.Add(new FormerEmployeeLookUpScreen(ScreenContentId));
                            break;
                        case ScreenName.CorporateEventsScreen:
                            ScreenPanel.Controls.Add(new CorporateEventsScreen());
                            break;
                        case ScreenName.CorporateEventsControl:
                            ScreenPanel.Controls.Add(new CorporateEventsControl(ScreenContentId));
                            break;
                        case ScreenName.BonusesScreen:
                            ScreenPanel.Controls.Add(new BonusesScreen(ScreenContentId));
                            break;
                        case ScreenName.BonusesControl:
                            ScreenPanel.Controls.Add(new BonusesControl(ScreenContentId));
                            break;
                        case ScreenName.EvaluationsScreen:
                            ScreenPanel.Controls.Add(new EvaluationsScreen(ScreenContentId));
                            break;
                        case ScreenName.EvaluationsControl:
                            ScreenPanel.Controls.Add(new EvaluationsControl(ScreenContentId));
                            break;
                        case ScreenName.EquipmentScreen:
                            ScreenPanel.Controls.Add(new EquipmentScreen(ScreenContentId));
                            break;
                        case ScreenName.ChangePasswordScreen:
                            ScreenPanel.Controls.Add(new ChangePasswordScreen(ScreenContentId));
                            break;
                        case ScreenName.WorkPlacesScreen:
                            ScreenPanel.Controls.Add(new WorkPlacesScreen());
                            break;
                        case ScreenName.WorkPlacesControl:
                            ScreenPanel.Controls.Add(new WorkPlacesControl(ScreenContentId));
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
