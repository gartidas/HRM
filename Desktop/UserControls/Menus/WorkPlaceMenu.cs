using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

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
            _toolTip.SetToolTip(workPlaceSpecialtiesButton, "Specialties");
            _toolTip.SetToolTip(workPlaceEvaluationsButton, "Evaluations");
        }

        private void workPlaceDataButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.WorkPlaceDataScreen);
        }

        private void workPlaceVacationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.WorkPlaceVacationsScreen);
        }

        private void workPlaceCorporateEventsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.WorkPlaceCorporateEventsScreen);
        }

        private void workPlaceSpecialtiesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.WorkPlaceSpecialtiesScreen);
        }

        private void workPlaceEvaluationsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.WorkPlaceEvaluationsScreen);
        }
    }
}
