using Desktop.Models;
using Desktop.Responses;
using Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class WorkPlacesControl : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();
        private List<Employee> _leaders = new List<Employee>();

        public WorkPlacesControl(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;
        }

        private async Task LoadWorkPlaceLeadersComboBoxAsync()
        {
            var response = await ApiHelper.Instance.GetAllEmployeesAsync(roleFilter: Role.WorkPlaceLeader.ToString());

            for (int i = 1; i <= response.Pages; i++)
            {
                _leaders.AddRange((await ApiHelper.Instance.GetAllEmployeesAsync(i, roleFilter: Role.WorkPlaceLeader.ToString())).Content);
            }

            foreach (var employee in _leaders)
            {
                workPlaceLeadersComboBox.Items.Add(employee.Data.EmailAddress);
            }
        }

        private async void WorkPlacesControl_Load(object sender, System.EventArgs e)
        {
            await LoadWorkPlaceLeadersComboBoxAsync();

            if (_id != default)
            {
                var result = await ApiHelper.Instance.GetSelectedWorkPlaceAsync(_id);
                if (result != null)
                    LoadData(result);
            }
        }

        public void LoadData(WorkPlace workPlace)
        {
            labelTextBox.Text = workPlace.Label;
            locationTextBox.Text = workPlace.Location;

            foreach (var item in workPlaceLeadersComboBox.Items)
            {
                if (item.ToString() == workPlace.WorkPlaceLeader)
                    workPlaceLeadersComboBox.SelectedItem = item;
            }
        }

        private async void submitButton_Click(object sender, System.EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox && (control as TextBox).Text == "")
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty.", (TextBox)control);
                    return;
                }
            }

            string leader = default;

            if (workPlaceLeadersComboBox.SelectedItem != default)
            {
                foreach (var workPlaceLeader in _leaders)
                {
                    if (workPlaceLeader.Data.EmailAddress == workPlaceLeadersComboBox.SelectedItem.ToString())
                    {
                        leader = workPlaceLeader.ID;
                        break;
                    }
                }
            }

            GenericResponse response = null;

            if (_id == default)
                response = await ApiHelper.Instance.AddWorkPlaceAsync(labelTextBox.Text, locationTextBox.Text, leader);
            else
                response = await ApiHelper.Instance.EditWorkPlaceAsync(_id, labelTextBox.Text, locationTextBox.Text, leader);

            if (response.Success)
            {
                ScreenLoading.LoadScreen(31);
            }
            else
            {
                errorLabel.Text = "";
                foreach (var error in response.Errors)
                {
                    errorLabel.Text += error;
                }
                errorLabel.Visible = true;
            }
        }
    }
}
