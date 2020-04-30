using Desktop.Models;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.Menus
{
    public partial class StaffMenu : UserControl
    {
        private ToolTip _toolTip = new ToolTip();

        public StaffMenu()
        {
            InitializeComponent();
            _toolTip.SetToolTip(candidatesButton, "Candidates");
            _toolTip.SetToolTip(employeesButton, "Employees");
            _toolTip.SetToolTip(formerEmployeesButton, "Former employees");
            _toolTip.SetToolTip(corporateEventsButton, "Corporate Events");

            if (CurrentUser.User.Role == Role.SysAdmin)
                corporateEventsButton.Enabled = false;
        }

        private void candidatesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.CandidatesScreen);
        }

        private void employeesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.EmployeesScreen);
        }

        private void formerEmployeesButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.FormerEmployeesScreen);
        }

        private void corporateEventsButton_Click(object sender, System.EventArgs e)
        {
            LoadScreen(ScreenName.CorporateEventsScreen);
        }
    }
}
