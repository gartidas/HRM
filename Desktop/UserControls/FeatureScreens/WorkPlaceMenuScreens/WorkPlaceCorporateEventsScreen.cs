using Desktop.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    public partial class WorkPlaceCorporateEventsScreen : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private List<Event> _corporateEvents = new List<Event>();
        private string _id;

        public WorkPlaceCorporateEventsScreen()
        {
            InitializeComponent();
        }

        private async Task LoadEmployeesComboBoxAsync()
        {
            var response = await ApiHelper.Instance.GetAllEmployeesAsync(workPlaceIdFilter: _id);

            for (int i = 1; i <= response.Pages; i++)
            {
                _employees.AddRange((await ApiHelper.Instance.GetAllEmployeesAsync(i, workPlaceIdFilter: _id)).Content.Where(x => x.Data.EmailAddress != CurrentUser.User.Email));
            }

            foreach (var employee in _employees)
                employeesComboBox.Items.Add(employee.Data.EmailAddress);
        }

        private async void WorkPlaceCorporateEventsScreen_Load(object sender, System.EventArgs e)
        {
            _id = (await ApiHelper.Instance.GetEmployeeDataAsync()).WorkPlace.ID;

            if (_id != default)
            {
                await LoadEmployeesComboBoxAsync();
                await LoadCorporateEventsListViewAsync();
                await LoadEmployeesListViewAsync();
            }

        }

        private async Task LoadCorporateEventsListViewAsync()
        {
            corporateEventsListView.Clear();

            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Empty", TextAlign = HorizontalAlignment.Center, Text = "" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Date", TextAlign = HorizontalAlignment.Center, Text = "Date" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Name", TextAlign = HorizontalAlignment.Center, Text = "Name" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Location", TextAlign = HorizontalAlignment.Center, Text = "Location" });
            corporateEventsListView.Columns.Add(new ColumnHeader { Name = "Description", TextAlign = HorizontalAlignment.Center, Text = "Description" });

            corporateEventsListView.View = View.Details;

            var response = await ApiHelper.Instance.GetCorporateEventsOfWorkPlaceAsync();

            if (response != null)
            {
                _corporateEvents = response.ToList();

                foreach (var corporateEvent in response)
                {
                    var item = new ListViewItem
                    {

                    };
                    item.SubItems.Clear();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.DateAndTime.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Name.ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.Location.ToString()));
                    if (corporateEvent.RequestDescription != null)
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, corporateEvent.RequestDescription.ToString()));

                    corporateEventsListView.Items.Add(item);
                }
            }

            corporateEventsListView.Columns[1].Width = -1;

            if (corporateEventsListView.Columns[1].Width < 100)
                corporateEventsListView.Columns[1].Width = 100;

            corporateEventsListView.Columns[2].Width = -1;

            if (corporateEventsListView.Columns[2].Width < 200)
                corporateEventsListView.Columns[2].Width = 200;

            corporateEventsListView.Columns[3].Width = -1;

            if (corporateEventsListView.Columns[3].Width < 100)
                corporateEventsListView.Columns[3].Width = 200;

            corporateEventsListView.Columns[4].Width = -1;

            if (corporateEventsListView.Columns[4].Width < 250)
                corporateEventsListView.Columns[4].Width = 250;
        }

        private async void corporateEventsListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            await LoadEmployeesListViewAsync();
        }

        private async Task LoadEmployeesListViewAsync()
        {
            employeesListView.Clear();

            employeesListView.Columns.Add(new ColumnHeader { Name = "Employees", TextAlign = HorizontalAlignment.Center, Width = employeesListView.Width, Text = "Employees" });
            employeesListView.View = View.Details;

            if (corporateEventsListView.SelectedIndices.Count > 0)
            {
                foreach (var corpEv in _corporateEvents)
                {
                    if (corpEv.DateAndTime.ToString() == corporateEventsListView.SelectedItems[0].SubItems[1].Text && corpEv.Name == corporateEventsListView.SelectedItems[0].SubItems[2].Text && corpEv.Location == corporateEventsListView.SelectedItems[0].SubItems[3].Text)
                    {
                        var response = await ApiHelper.Instance.GetCorporateEventAsync(corpEv.ID);
                        if (response != null && response.InvitedEmployees != null)
                        {
                            foreach (var employee in response.InvitedEmployees)
                            {
                                var item = new ListViewItem
                                {
                                    Text = employee.Email
                                };

                                employeesListView.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private async void addEmployeeButton_Click(object sender, System.EventArgs e)
        {
            if (corporateEventsListView.SelectedIndices.Count > 0 && employeesComboBox.SelectedIndex != -1)
            {
                foreach (var corpEv in _corporateEvents)
                {
                    if (corpEv.DateAndTime.ToString() == corporateEventsListView.SelectedItems[0].SubItems[1].Text && corpEv.Name == corporateEventsListView.SelectedItems[0].SubItems[2].Text && corpEv.Location == corporateEventsListView.SelectedItems[0].SubItems[3].Text)
                    {
                        foreach (var employee in _employees)
                        {
                            if (employee.Data.EmailAddress == employeesComboBox.SelectedItem.ToString())
                            {
                                var response = await ApiHelper.Instance.AssignEmployeeToCorporateEventAsync(corpEv.ID, employee.ID);

                                if (response.Success)
                                {
                                    employeesComboBox.SelectedIndex = -1;
                                    await LoadEmployeesListViewAsync();
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void removeEmployeeButton_Click(object sender, System.EventArgs e)
        {
            if (corporateEventsListView.SelectedIndices.Count > 0 && employeesListView.SelectedIndices.Count > 0)
            {
                foreach (var corpEv in _corporateEvents)
                {
                    if (corpEv.DateAndTime.ToString() == corporateEventsListView.SelectedItems[0].SubItems[1].Text && corpEv.Name == corporateEventsListView.SelectedItems[0].SubItems[2].Text && corpEv.Location == corporateEventsListView.SelectedItems[0].SubItems[3].Text)
                    {
                        foreach (var employee in _employees)
                        {
                            if (employee.Data.EmailAddress == employeesListView.SelectedItems[0].Text)
                            {
                                var response = await ApiHelper.Instance.RemoveEmployeeFromCorporateEventAsync(corpEv.ID, employee.ID);

                                if (response.Success)
                                {
                                    await LoadEmployeesListViewAsync();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
