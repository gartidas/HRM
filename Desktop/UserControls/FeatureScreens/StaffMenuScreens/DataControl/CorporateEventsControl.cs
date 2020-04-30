using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop.Utils.ContentLoading;

namespace Desktop.UserControls.FeatureScreens.StaffMenuScreens.DataControl
{
    public partial class CorporateEventsControl : UserControl
    {
        private string _id;
        private ToolTip _toolTip = new ToolTip();
        private List<Employee> _leaders = new List<Employee>();

        public CorporateEventsControl(string id)
        {
            InitializeComponent();
            _id = id;
            _toolTip.IsBalloon = true;
            dateTimePicker.MinDate = DateTime.Now.Date.AddDays(1);
        }

        private async void CorporateEventsControl_Load(object sender, System.EventArgs e)
        {
            if (_id == default)
                return;

            eventsControlPanel.Visible = true;
            workPlaceLeadersListView.Visible = true;

            var eventResult = await ApiHelper.Instance.GetSelectedCorporateEventAsync(_id);

            if (eventResult != null)
                LoadComponents(eventResult);

            await LoadWorkPlaceLeadersComboBoxAsync();
            await LoadWorkPlaceLeadersListViewAsync();
        }

        private void LoadComponents(Event corporateEvent)
        {
            nameTextBox.Text = corporateEvent.Name;
            locationTextBox.Text = corporateEvent.Location;
            requestTextBox.Text = corporateEvent.RequestDescription;

            if (corporateEvent.DateAndTime >= dateTimePicker.MinDate)
                dateTimePicker.Value = corporateEvent.DateAndTime;
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

        private async Task LoadWorkPlaceLeadersListViewAsync()
        {
            workPlaceLeadersListView.Clear();

            workPlaceLeadersListView.Columns.Add(new ColumnHeader { Name = "WorkplaceLeaders", TextAlign = HorizontalAlignment.Center, Width = workPlaceLeadersListView.Width, Text = "Workplace leaders" });
            workPlaceLeadersListView.View = View.Details;


            var response = await ApiHelper.Instance.GetSelectedCorporateEventAsync(_id);

            if (response != null && response.InvitedWorkPlaceLeaders != null)
            {
                foreach (var workPlaceLeader in response.InvitedWorkPlaceLeaders)
                {
                    var item = new ListViewItem
                    {
                        Text = workPlaceLeader.Email
                    };

                    workPlaceLeadersListView.Items.Add(item);
                }
            }
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (workPlaceLeadersComboBox.SelectedIndex != -1)
            {
                foreach (var leader in _leaders)
                {
                    if (leader.Data.EmailAddress == workPlaceLeadersComboBox.SelectedItem.ToString())
                    {
                        var response = await ApiHelper.Instance.AssignWorkPlaceLeaderToCorporateEventAsync(_id, leader.ID);

                        if (response.Success)
                        {
                            workPlaceLeadersComboBox.SelectedIndex = -1;
                            await LoadWorkPlaceLeadersListViewAsync();
                            return;
                        }
                    }
                }
            }
        }

        private async void removeButton_Click(object sender, EventArgs e)
        {
            if (workPlaceLeadersListView.SelectedIndices.Count > 0)
            {
                foreach (var leader in _leaders)
                {
                    if (leader.Data.EmailAddress == workPlaceLeadersListView.SelectedItems[0].Text)
                    {
                        var response = await ApiHelper.Instance.RemoveWorkPlaceLeaderFromCorporateEventAsync(_id, leader.ID);

                        if (response.Success)
                        {
                            workPlaceLeadersComboBox.SelectedIndex = -1;
                            await LoadWorkPlaceLeadersListViewAsync();
                            return;
                        }
                    }
                }
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                if (control is TextBox && (control as TextBox).Text == "" && !(control as TextBox).Equals(requestTextBox))
                {
                    var name = ((TextBox)control).Name.Replace("TextBox", "");
                    name = (string.Concat(name.Select(x => Char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' '));
                    name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();

                    _toolTip.Show($"{name} is empty", (TextBox)control);
                    return;
                }
            }

            GenericResponse response = null;

            if (_id == default)
                response = await ApiHelper.Instance.AddCorporateEventAsync(nameTextBox.Text, locationTextBox.Text, dateTimePicker.Value, requestTextBox.Text);
            else
                response = await ApiHelper.Instance.EditCorporateEventAsync(_id, nameTextBox.Text, locationTextBox.Text, dateTimePicker.Value, requestTextBox.Text);

            if (response.Success)
            {
                LoadScreen(ScreenName.CorporateEventsScreen);
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
