using Desktop.Forms;

namespace Desktop.Utils
{
    public class ContentLoading
    {
        #region Screens
        public static void LoadScreen(ScreenName screenName)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden)
                    MainFormStateSingleton.Instance.ScreenOpened = screenName;

                if (MainFormStateSingleton.Instance.ScreenOpened == screenName)
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.ScreenOpened = screenName;
                    MainFormStateSingleton.Instance.ScreensChanging = true;
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                }
            }
        }

        public static void SetScreenContent(string id)
        {
            MainFormStateSingleton.Instance.ScreenContentId = id;
        }

        public enum ScreenName
        {
            PersonalDataScreen,
            PersonalChangePasswordScreen,
            PersonalVacationsScreen,
            PersonalCorporateEventsScreen,
            PersonalEvaluationsScreen,
            PersonalBonusesScreen,
            PersonalEquipmentScreen,
            WorkPlaceDataScreen,
            WorkPlaceVacationsScreen,
            WorkPlaceCorporateEventsScreen,
            WorkPlaceSpecialtiesScreen,
            WorkPlaceEvaluationsScreen,
            DocumentationScreenCandidates,
            DocumentationScreenEmployees,
            DocumentationScreenFormerEmployees,
            CandidatesScreen,
            CandidatesControl,
            EmployeesScreen,
            EmployeesControl,
            HireEmployeeControl,
            FormerEmployeesScreen,
            FormerEmployeeLookUpScreen,
            CorporateEventsScreen,
            CorporateEventsControl,
            BonusesScreen,
            BonusesControl,
            EvaluationsScreen,
            EvaluationsControl,
            EquipmentScreen,
            ChangePasswordScreen,
            WorkPlacesScreen,
            WorkPlacesControl
        }
        #endregion

        #region Menus
        public static void LoadMenu(MenuName menuName)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden == true)
                {
                    if (MainFormStateSingleton.Instance.MenuHidden)
                        MainFormStateSingleton.Instance.MenuOpened = menuName;

                    if (MainFormStateSingleton.Instance.MenuOpened == menuName)
                        MainFormStateSingleton.Instance.MenuTimer.Start();
                    else
                    {
                        MainFormStateSingleton.Instance.MenuOpened = menuName;
                        MainFormStateSingleton.Instance.MenusChanging = true;
                        MainFormStateSingleton.Instance.MenuTimer.Start();
                    }
                }
                else
                {
                    if (MainFormStateSingleton.Instance.MenuOpened == menuName)
                    {
                        MainFormStateSingleton.Instance.MenuClosing = true;
                        MainFormStateSingleton.Instance.ScreenTimer.Start();
                    }
                    else
                    {
                        MainFormStateSingleton.Instance.MenuClosing = true;
                        MainFormStateSingleton.Instance.MenuOpened = menuName;
                        MainFormStateSingleton.Instance.MenusChanging = true;
                        MainFormStateSingleton.Instance.ScreenTimer.Start();
                    }
                }
            }
        }

        public enum MenuName
        {
            PersonalMenu,
            WorkPlaceMenu,
            StaffMenu,
            MaintenanceMenu
        }
        #endregion
    }
}
