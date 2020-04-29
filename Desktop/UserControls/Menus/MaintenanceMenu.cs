using Desktop.Utils;
using System;
using System.Windows.Forms;

namespace Desktop.UserControls.Menus
{
    public partial class MaintenanceMenu : UserControl
    {
        private ToolTip _toolTip = new ToolTip();

        public MaintenanceMenu()
        {
            InitializeComponent();
            _toolTip.SetToolTip(workplacesButton, "Workplaces");
        }

        private void workplacesButton_Click(object sender, EventArgs e)
        {
            ScreenLoading.LoadScreen(31);
        }
    }
}
