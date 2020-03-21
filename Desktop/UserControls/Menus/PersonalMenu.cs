using Desktop.Forms;
using Desktop.UserControls.FeatureScreens;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class PersonalMenu : UserControl
    {
        private ChangePasswordScreen _changePasswordScreen = new ChangePasswordScreen();
        private PersonalDataScreen _personalDataScreen = new PersonalDataScreen();

        public PersonalMenu(string email, string role)
        {
            InitializeComponent();
            emailLabel.Text = email;
            roleLabel.Text = role;
            MainFormStateSingleton.Instance.changePasswordScreen = _changePasswordScreen;
            MainFormStateSingleton.Instance.personalDataScreen = _personalDataScreen;
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
            if (!MainFormStateSingleton.Instance.screenMoving && !MainFormStateSingleton.Instance.menuMoving)
            {
                if (MainFormStateSingleton.Instance.screenHidden)
                    MainFormStateSingleton.Instance.screenOpened = screenNumber;

                if (MainFormStateSingleton.Instance.screenOpened == screenNumber)
                    MainFormStateSingleton.Instance.screenTimer.Start();
                else
                {
                    MainFormStateSingleton.Instance.screenOpened = screenNumber;
                    MainFormStateSingleton.Instance.screensChanging = true;
                    MainFormStateSingleton.Instance.screenTimer.Start();
                }
            }
        }
    }
}
