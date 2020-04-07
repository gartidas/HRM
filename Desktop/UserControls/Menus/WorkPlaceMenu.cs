using Desktop.Forms;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class WorkPlaceMenu : UserControl
    {
        private ToolTip _toolTip = new ToolTip();

        public WorkPlaceMenu()
        {
            InitializeComponent();
            _toolTip.SetToolTip(workPlaceDataButton, "Workplace");
            _toolTip.SetToolTip(workPlaceVacationsButton, "Vacations");
            _toolTip.SetToolTip(workPlaceCorporateEventsButton, "Corporate events");
        }

        private void workPlaceDataButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(8);
        }

        private void workPlaceVacationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(9);
        }

        private void workPlaceCorporateEventsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(10);
        }

        private void workPlaceSpecialtiesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(11);
        }

        private void workPlaceEvaluationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(12);
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
