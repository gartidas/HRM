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
            //if (_panelHidden)
            //    _panelOpened = 1;

            //if (_panelOpened == 1)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 1;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 2;

            //if (_panelOpened == 2)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 2;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void vacationsButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 3;

            //if (_panelOpened == 3)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 3;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void corporateEventsButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 4;

            //if (_panelOpened == 4)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 4;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void evaluationsButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 5;

            //if (_panelOpened == 5)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 5;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void bonusesButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 6;

            //if (_panelOpened == 6)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 6;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }

        private void equipmentButton_Click(object sender, System.EventArgs e)
        {
            //if (_panelHidden)
            //    _panelOpened = 7;

            //if (_panelOpened == 7)
            //    loadPanelTimer.Start();
            //else
            //{
            //    _panelOpened = 7;
            //    _panelsChanging = true;
            //    loadPanelTimer.Start();
            //}
        }
    }
}
