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
        private List<Specialty> _neededSpecialties = new List<Specialty>();
        private List<Specialty> _realSpecialties = new List<Specialty>();
        private List<WorkPlaceVacation> _employeeVacations = new List<WorkPlaceVacation>();
        private ToolTip _toolTip = new ToolTip();
        private string _errorMessage;
        private string errorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    if (value != $"Missing employees:{Environment.NewLine}")
                        warningPictureBox.Visible = true;
                }
            }
        }
        private string _id;


        public WorkPlaceVacationsScreen()
        {
            InitializeComponent();
        }

        private async void WorkPlaceVacationsScreen_Load(object sender, EventArgs e)
        {
            var result = await ApiHelper.Instance.GetEmployeeDataAsync();

            if (result == null)
                return;

            _id = result.WorkPlace.ID;
            vacationsCalendar.LoadPresetHolidays = false;
            vacationsCalendar.AllowEditingEvents = false;
            vacationsCalendar.CalendarDate = DateTime.Now;

            if (_id != default)
            {
                _neededSpecialties = (await ApiHelper.Instance.GetAllSpecialtiesOfWorkplaceAsync(_id)).ToList();
                if (_neededSpecialties != null)
                    await LoadEmployeesComboBoxAsync();
            }
        }

        private async Task LoadEmployeesComboBoxAsync()
        {
            bool found = false;
            var response = await ApiHelper.Instance.GetAllEmployeesAsync(workPlaceIdFilter: _id);

            for (int i = 1; i <= response.Pages; i++)
            {
                _employees.AddRange((await ApiHelper.Instance.GetAllEmployeesAsync(i, workPlaceIdFilter: _id)).Content);
            }

            employeeComboBox.Items.Add("All");

            foreach (var employee in _employees)
            {
                if (employee.Data.EmailAddress != CurrentUser.User.Email)
                    employeeComboBox.Items.Add(employee.Data.EmailAddress);

                foreach (var specialty in _realSpecialties)
                {
                    if (specialty.Name.ToLower() == employee.Data.Specialty.ToLower())
                    {
                        found = true;
                        specialty.NumberOfEmployees++;
                    }
                }

                if (!found)
                    _realSpecialties.Add(new Specialty { Name = employee.Data.Specialty, NumberOfEmployees = 1 });

                found = false;
            }

            CheckWorkPlaceStatus();
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
            bool foundDate = false;
            bool foundSpecialty = false;
            if (employeeEmail == "All")
            {
                vacationsCountLabel.Visible = false;

                _employeeVacations = new List<WorkPlaceVacation>();

                foreach (var employee in _employees)
                {
                    var vacationsIE = (await ApiHelper.Instance.GetSelectedEmployeeVacationsAsync(employee.ID));

                    if (vacationsIE != null)
                    {
                        var vacations = vacationsIE.Where(x => x.Approved).ToList();

                        foreach (var employeeVacation in vacations)
                        {

                            foreach (var workPlaceVacation in _employeeVacations)
                            {
                                if (workPlaceVacation.Date == employeeVacation.DateAndTime)
                                {
                                    foundDate = true;
                                    foreach (var specialty in workPlaceVacation.Specialties)
                                    {
                                        if (specialty.Name.ToLower() == employee.Data.Specialty.ToLower())
                                        {
                                            foundSpecialty = true;
                                            specialty.NumberOfEmployees++;
                                        }
                                    }

                                    if (!foundSpecialty)
                                        workPlaceVacation.Specialties.Add(new Specialty { Name = employee.Data.Specialty, NumberOfEmployees = 1 });

                                    foundSpecialty = false;
                                }
                            }

                            if (!foundDate)
                            {
                                var specialty = new Specialty { Name = employee.Data.Specialty, NumberOfEmployees = 1 };
                                var vacation = new WorkPlaceVacation { Date = employeeVacation.DateAndTime };
                                vacation.Specialties = new List<Specialty>();
                                vacation.Specialties.Add(specialty);
                                _employeeVacations.Add(vacation);
                            }

                            foundDate = false;
                        }
                    }
                }

                if (_employeeVacations != null)
                {
                    LoadWorkPlaceVacationsCalendar(_employeeVacations);
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
                            LoadEmployeeVacationsCalendar(_vacations);

                            foreach (var vacation in _vacations)
                            {
                                vacationsComboBox.Items.Add(vacation.DateAndTime);
                            }

                            vacationsCountLabel.Text = (employee.Data.NumberOfVacationDays - _vacations.Where(x => x.Approved).Count()).ToString();
                        }
                        else
                        {
                            foreach (var vacation in _events)
                            {
                                vacationsCalendar.RemoveEvent(vacation);
                            }
                            _events.Clear();

                            vacationsCountLabel.Text = employee.Data.NumberOfVacationDays.ToString();
                        }

                        vacationsCountLabel.Visible = true;
                    }
                }
            }
        }

        private void LoadEmployeeVacationsCalendar(List<Vacation> vacations)
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

        private void LoadWorkPlaceVacationsCalendar(List<WorkPlaceVacation> vacations)
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
                string specialties = $"Vacations:{Environment.NewLine}";

                foreach (var specialty in vacation.Specialties)
                {
                    specialties += $"Spec.:{specialty.Name} ({specialty.NumberOfEmployees}){Environment.NewLine}";
                }

                var newVacation = new CustomEvent
                {
                    Date = vacation.Date,
                    EventColor = Color.Gray,
                    EventTextColor = Color.White,
                    EventText = specialties,
                    IgnoreTimeComponent = true
                };

                _events.Add(newVacation);
                vacationsCalendar.AddEvent(newVacation);
            }
        }

        private async void approveVacationButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(vacationsCountLabel.Text) == 0)
            {
                errorLabel.Text = "There are no free vacations left";
                return;
            }

            await SetVacationApprovedState(true);
        }

        private async void cancelVacationButton_Click(object sender, EventArgs e)
        {
            await SetVacationApprovedState(false);
        }

        private async Task SetVacationApprovedState(bool approved)
        {
            if (vacationsComboBox.SelectedIndex != -1)
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
                            return;
                        }
                    }
                }
            }
        }

        private void CheckWorkPlaceStatus()
        {
            errorMessage = $"Missing employees:{Environment.NewLine}";
            bool found = false;

            foreach (var neededSpecialty in _neededSpecialties)
            {
                foreach (var realSpecialty in _realSpecialties)
                {
                    if (neededSpecialty.Name == realSpecialty.Name)
                    {
                        found = true;
                        if (neededSpecialty.NumberOfEmployees > realSpecialty.NumberOfEmployees)
                            errorMessage += $"Specialty:{neededSpecialty.Name} ({neededSpecialty.NumberOfEmployees - realSpecialty.NumberOfEmployees}){Environment.NewLine}";
                    }
                }

                if (!found)
                    errorMessage += $"Specialty:{neededSpecialty.Name} ({neededSpecialty.NumberOfEmployees}){Environment.NewLine}";

                found = false;
            }
        }

        private void warningPictureBox_MouseEnter(object sender, EventArgs e)
        {
            _toolTip.Show(errorMessage, warningPictureBox, 1000000000);
        }

        private void warningPictureBox_MouseLeave(object sender, EventArgs e)
        {
            _toolTip.Hide(warningPictureBox);
        }

        private void errorLabel_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = true;
        }
    }
}