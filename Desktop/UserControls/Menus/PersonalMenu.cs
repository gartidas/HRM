using Desktop.Forms;
using Desktop.UserControls.FeatureScreens;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class PersonalMenu : UserControl
    {
        private ChangePasswordScreen _changePasswordScreen = new ChangePasswordScreen();
        private PersonalDataScreen _personalDataScreen = new PersonalDataScreen();
        private MainFormStateSingleton _mainFormStateSingleton = new MainFormStateSingleton();

        public PersonalMenu(string email, string role)
        {
            InitializeComponent();
            emailLabel.Text = email;
            roleLabel.Text = role;
            MainFormStateSingleton.changePasswordScreen = _changePasswordScreen;
            MainFormStateSingleton.personalDataScreen = _personalDataScreen;
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
            if (MainFormStateSingleton.screenHidden)
                MainFormStateSingleton.screenOpened = screenNumber;

            if (MainFormStateSingleton.screenOpened == screenNumber)
                MainFormStateSingleton.screenTimer.Start();
            else
            {
                MainFormStateSingleton.screenOpened = screenNumber;
                MainFormStateSingleton.screensChanging = true;
                MainFormStateSingleton.screenTimer.Start();
            }
        }
    }
}
