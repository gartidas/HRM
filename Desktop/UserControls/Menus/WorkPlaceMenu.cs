using Desktop.Utils;
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
            ScreenLoading.LoadScreen(8);
        }

        private void workPlaceVacationsButton_Click(object sender, System.EventArgs e)
        {
            ScreenLoading.LoadScreen(9);
        }

        private void workPlaceCorporateEventsButton_Click(object sender, System.EventArgs e)
        {
            ScreenLoading.LoadScreen(10);
        }

        private void workPlaceSpecialtiesButton_Click(object sender, System.EventArgs e)
        {
            ScreenLoading.LoadScreen(11);
        }

        private void workPlaceEvaluationsButton_Click(object sender, System.EventArgs e)
        {
            ScreenLoading.LoadScreen(12);
        }
    }
}
