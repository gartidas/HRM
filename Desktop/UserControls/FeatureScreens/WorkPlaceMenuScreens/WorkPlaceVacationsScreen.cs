using Calendar.NET;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.WorkPlaceMenuScreens
{
    public partial class WorkPlaceVacationsScreen : UserControl
    {
        private List<Employee> _employees = new List<Employee>();
        private List<Vacation> _vacations = new List<Vacation>();
        private List<CustomEvent> _events = new List<CustomEvent>();

        public WorkPlaceVacationsScreen()
        {
            InitializeComponent();
        }

        private async void WorkPlaceVacationsScreen_Load(object sender, EventArgs e)
        {
            vacationsCalendar.LoadPresetHolidays = false;
            vacationsCalendar.AllowEditingEvents = false;
            vacationsCalendar.CalendarDate = DateTime.Now;
            await LoadEmployeesComboBoxAsync();
        }

        private async Task LoadEmployeesComboBoxAsync()
        {
            var id = (await ApiHelper.Instance.GetEmployeeDataAsync()).WorkPlace.ID;
            var response = await ApiHelper.Instance.GetAllEmployeesOfWorkPlaceAsync(id);

            for (int i = 1; i <= response.Pages; i++)
            {
                _employees.AddRange((await ApiHelper.Instance.GetAllEmployeesOfWorkPlaceAsync(id, i)).Content);
            }

            employeeComboBox.Items.Add("All");

            foreach (var employee in _employees)
            {
                employeeComboBox.Items.Add(employee.Data.EmailAddress);
            }
        }

        private async void employeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vacationsComboBox.Items.Clear();
            vacationsComboBox.ResetText();
            vacationsComboBox.SelectedIndex = -1;

            await LoadVacationsComboBoxAsync(employeeComboBox.SelectedItem.ToString());
        }

        private async Task LoadVacationsComboBoxAsync(string employeeEmail)
        {
            if (employeeEmail == "All")
            {
                foreach (var employee in _employees)
                {
                    var vacationsIE = (await ApiHelper.Instance.GetSelectedEmployeeVacationsAsync(employee.ID));

                    if (vacationsIE != null)
                    {
                        _vacations = vacationsIE.ToList();
                    }
                }

                if (_vacations != null)
                {
                    foreach (var vacation in _vacations)
                    {
                        if (vacation.Approved)
                        {
                            //<--TU
                        }
                    }
                }
            }
            else
            {
                foreach (var employee in _employees)
                {
                    if (employee.Data.EmailAddress == employeeEmail)
                    {
                        var vacationsIE = (await ApiHelper.Instance.GetSelectedEmployeeVacationsAsync(employee.ID));

                        if (vacationsIE != null)
                        {
                            _vacations = vacationsIE.ToList();
                            LoadVacationsCalendar(_vacations);

                            foreach (var vacation in _vacations)
                            {
                                vacationsComboBox.Items.Add(vacation.DateAndTime);
                            }
                        }
                        else
                        {
                            foreach (var vacation in _events)
                            {
                                vacationsCalendar.RemoveEvent(vacation);
                            }
                            _events.Clear();
                        }
                    }
                }
            }
        }

        private void LoadVacationsCalendar(List<Vacation> vacations)
        {
            vacationsCalendar.LoadPresetHolidays = false;
            vacationsCalendar.AllowEditingEvents = false;
            vacationsCalendar.CalendarDate = DateTime.Now;

            foreach (var vacation in _events)
            {
                vacationsCalendar.RemoveEvent(vacation);
            }
            _events.Clear();


            foreach (var vacation in vacations)
            {
                var newVacation = new CustomEvent
                {
                    Date = vacation.DateAndTime,
                    EventColor = vacation.Approved ? Color.DarkGreen : Color.DarkRed,
                    EventTextColor = Color.White,
                    EventText = vacation.Reason,
                    IgnoreTimeComponent = true
                };

                _events.Add(newVacation);
                vacationsCalendar.AddEvent(newVacation);
            }
        }

        private async void approveVacationButton_Click(object sender, EventArgs e)
        {
            await SetVacationApprovedState(true);
        }

        private async void cancelVacationButton_Click(object sender, EventArgs e)
        {
            await SetVacationApprovedState(false);
        }

        private async Task SetVacationApprovedState(bool approved)
        {
            foreach (var vacation in _vacations)
            {
                if (vacation.DateAndTime == (DateTime)vacationsComboBox.SelectedItem && (DateTime)vacationsComboBox.SelectedItem > DateTime.Now.Date)
                {
                    var response = await ApiHelper.Instance.SetEmployeeVacationApprovedStateAsync(vacation.ID, approved);

                    if (response.Success == true)
                    {
                        vacationsComboBox.Items.Clear();
                        vacationsComboBox.ResetText();
                        vacationsComboBox.SelectedIndex = -1;

                        await LoadVacationsComboBoxAsync(employeeComboBox.SelectedItem.ToString());
                    }
                }
            }
        }
    }
}
