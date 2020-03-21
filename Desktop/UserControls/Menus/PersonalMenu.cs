using Desktop.Forms;
using Desktop.UserControls.FeatureScreens;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class PersonalMenu : UserControl
    {
        private ChangePasswordScreen _changePasswordScreen = new ChangePasswordScreen();
        private PersonalDataScreen _personalDataScreen = new PersonalDataScreen();
        private ToolTip _toolTip = new ToolTip();

        public PersonalMenu(string email, string role)
        {
            InitializeComponent();
            emailLabel.Text = email;
            roleLabel.Text = role;
            _toolTip.SetToolTip(personalDataButton, "Personal data");
            _toolTip.SetToolTip(changePasswordButton, "Change password");
            _toolTip.SetToolTip(vacationsButton, "Vacations");
            _toolTip.SetToolTip(corporateEventsButton, "Corporate Events");
            _toolTip.SetToolTip(evaluationsButton, "Evaluations");
            _toolTip.SetToolTip(bonusesButton, "Bonuses");
            _toolTip.SetToolTip(equipmentButton, "Equipment");
            MainFormStateSingleton.Instance.ChangePasswordScreen = _changePasswordScreen;
            MainFormStateSingleton.Instance.PersonalDataScreen = _personalDataScreen;
        }

        private void personalDataButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(1);
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(2);
        }

        private void vacationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(3);
        }

        private void corporateEventsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(4);
        }

        private void evaluationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(5);
        }

        private void bonusesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(6);
        }

        private void equipmentButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(7);
        }

        private void LoadScreen(int screenNumber)
        {
            if (!MainFormStateSingleton.Instance.ScreenMoving && !MainFormStateSingleton.Instance.MenuMoving)
            {
                if (MainFormStateSingleton.Instance.ScreenHidden)
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;

                if (MainFormStateSingleton.Instance.ScreenOpened == screenNumber)
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.ScreenOpened = screenNumber;
                    MainFormStateSingleton.Instance.ScreensChanging = true;
                    MainFormStateSingleton.Instance.ScreenTimer.Start();
                }
            }
        }
    }
}
