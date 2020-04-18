using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class EmployeesControl : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();

        public EmployeesControl(string id)
        {
            InitializeComponent();
            _toolTip.IsBalloon = true;
            _id = id;
        }
    }
}
