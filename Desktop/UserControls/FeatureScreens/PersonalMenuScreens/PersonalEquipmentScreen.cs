using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    public partial class PersonalEquipmentScreen : UserControl
    {
        public PersonalEquipmentScreen()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
        {
            equipmentListView.Clear();

            var column = new ColumnHeader { Name = "Label", TextAlign = HorizontalAlignment.Center, Width = equipmentListView.Width, Text = "Label" };
            equipmentListView.Columns.Add(column);
            equipmentListView.View = View.Details;

            var statusResponse = await ApiHelper.Instance.GetMeEquipmentStatusAsync();

            switch (statusResponse)
            {
                case Models.EquipmentStatus.NotReceived:
                    statusLabel.Text = "Not received";
                    break;
                case Models.EquipmentStatus.Received:
                    statusLabel.Text = "Received";
                    break;
                case Models.EquipmentStatus.RequestedReturn:
                    statusLabel.Text = "Requested return";
                    break;
                case Models.EquipmentStatus.Returned:
                    statusLabel.Text = "Returned";
                    break;
                default:
                    break;
            }

            var response = await ApiHelper.Instance.GetMeEquipmentAsync();

            if (response != null)
            {
                foreach (var equipmentItem in response)
                {
                    var item = new ListViewItem
                    {
                        Text = equipmentItem.Label,
                    };

                    equipmentListView.Items.Add(item);
                }
            }
        }

        private void statusLabel_TextChanged(object sender, System.EventArgs e)
        {
            statusLabel.Visible = true;
        }

        private async void EquipmentScreen_Load(object sender, System.EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
