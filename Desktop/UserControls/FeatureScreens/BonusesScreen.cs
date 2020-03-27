using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens
{
    public partial class BonusesScreen : UserControl
    {
        public BonusesScreen()
        {
            InitializeComponent();
        }

        public async Task LoadDataAsync()
        {
            bonusesListView.Clear();

            var column1 = new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" };
            var column2 = new ColumnHeader { Name = "Date", TextAlign = HorizontalAlignment.Center, Text = "Date" };
            var column3 = new ColumnHeader { Name = "Value", TextAlign = HorizontalAlignment.Center, Text = "Value" };
            var column4 = new ColumnHeader { Name = "Description", TextAlign = HorizontalAlignment.Center, Text = "Reason" };

            bonusesListView.Columns.Add(column1);
            bonusesListView.Columns.Add(column2);
            bonusesListView.Columns.Add(column3);
            bonusesListView.Columns.Add(column4);

            bonusesListView.View = View.Details;

            var response = await ApiHelper.Instance.GetEmployeeBonusesAsync();

            if (response != null)
            {
                foreach (var bonus in response)
                {
                    var item = new ListViewItem
                    {
                        ToolTipText = $@"Name: {bonus.HR_Worker.Name}
Email: {bonus.HR_Worker.Email}"
                    };
                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.GrantedDate.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.Value.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, bonus.Description.ToString()));

                    bonusesListView.Items.Add(item);
                }
            }

            for (int i = 1; i < bonusesListView.Columns.Count; i++)
            {
                if (i == 2)
                {
                    bonusesListView.Columns[i].Width = -1;

                    if (bonusesListView.Columns[i].Width < 100)
                        bonusesListView.Columns[i].Width = 100;
                    continue;
                }
                bonusesListView.Columns[i].Width = -1;
            }
        }

        private async void BonusesScreen_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
