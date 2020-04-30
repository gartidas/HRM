using Desktop.Forms;
using Desktop.Models;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens
{
    public partial class EquipmentScreen : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();
        private List<EquipmentItem> _equipment = new List<EquipmentItem>();
        private bool _loaded;

        public EquipmentScreen(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;

            foreach (var status in Enum.GetValues(typeof(EquipmentStatus)))
            {
                var str = (string.Concat(status.ToString().Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                statusComboBox.Items.Add(str[0] + str.Substring(1).ToLower());
            }
        }

        private async Task LoadDataAsync()
        {
            equipmentListView.Clear();

            var column = new ColumnHeader { Name = "Label", TextAlign = HorizontalAlignment.Center, Width = equipmentListView.Width, Text = "Label" };
            equipmentListView.Columns.Add(column);
            equipmentListView.View = View.Details;

            var response = await ApiHelper.Instance.GetEquipmentOfSelectedEmployeeAsync(_id);

            if (response != null)
            {
                _equipment = response.ToList();

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

        private async Task SelectStatusAsync()
        {
            var statusResponse = await ApiHelper.Instance.GetEquipmentStatusOfSelectedEmployeeAsync(_id);

            foreach (var item in statusComboBox.Items)
            {
                if (item.ToString().Replace(" ", string.Empty).ToLower() == statusResponse.ToString().ToLower())
                    statusComboBox.SelectedItem = item;
            }

            _loaded = true;
        }

        private async Task LoadEmailLabelAsync()
        {
            var result = await ApiHelper.Instance.GetSelectedEmployeeDataAsync(_id);

            if (result != null)
            {
                emailLabel.Text = result.Data.EmailAddress;
                emailLabel.Visible = true;
            }
        }

        private async void EquipmentScreen_Load(object sender, EventArgs e)
        {
            if (_id == default)
                return;

            await LoadDataAsync();
            await LoadEmailLabelAsync();
            await SelectStatusAsync();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (labelTextBox.Text == "")
            {
                _toolTip.Show("Label is empty", labelTextBox);
                return;
            }

            var response = await ApiHelper.Instance.AddEquipmentItemForEmployeeAsync(_id, labelTextBox.Text);

            if (response.Success)
            {
                errorLabel.Visible = false;
                labelTextBox.Text = "";
                await LoadDataAsync();
                return;
            }

            errorLabel.Text = "";

            foreach (var error in response.Errors)
            {
                errorLabel.Text += error;
            }

            errorLabel.Visible = true;
        }

        private async void removeButton_Click(object sender, EventArgs e)
        {
            if (equipmentListView.SelectedIndices.Count > 0)
            {
                foreach (var item in _equipment)
                {
                    if (equipmentListView.SelectedItems[0].Text == item.Label)
                    {
                        var response = await ApiHelper.Instance.RemoveEquipmentItemAsync(item.ID);

                        if (response.Success)
                        {
                            errorLabel.Visible = false;
                            await LoadDataAsync();
                            return;
                        }

                        errorLabel.Text = "";
                        errorLabel.Text += response.ErrorMessage;
                        errorLabel.Visible = true;
                        return;
                    }
                }
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            ScreenLoading.LoadScreen(MainFormStateSingleton.Instance.LastLoadedScreen);

        }

        private async void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loaded)
                return;

            var strSelItem = statusComboBox.SelectedItem.ToString().Split(' ');
            string status = "";

            for (int i = 0; i < strSelItem.Length; i++)
            {
                status += Char.ToUpper(strSelItem[i][0]) + strSelItem[i].Substring(1);
            }

            EquipmentStatus enumStat = (EquipmentStatus)(Enum.Parse(typeof(EquipmentStatus), status));

            var response = await ApiHelper.Instance.SetEquipmentStatusOfEmployeeAsync(_id, enumStat);

            if (response.Success)
            {
                errorLabel.Visible = false;
                return;
            }

            errorLabel.Text = "";

            foreach (var error in response.Errors)
            {
                errorLabel.Text += error;
            }

            errorLabel.Visible = true;
            return;
        }
    }
}
