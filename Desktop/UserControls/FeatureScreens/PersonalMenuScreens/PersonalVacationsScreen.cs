using Calendar.NET;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens.PersonalMenuScreens
{
    public partial class PersonalVacationsScreen : UserControl
    {
        private List<CustomEvent> _events = new List<CustomEvent>();
        private List<Vacation> _vacations = new List<Vacation>();
        private int _numberOfVacations;

        public PersonalVacationsScreen()
        {
            InitializeComponent();
        }

        private async Task LoadDataAsync()
        {
            vacationsCalendar.LoadPresetHolidays = false;
            vacationsCalendar.AllowEditingEvents = false;
            vacationsCalendar.CalendarDate = DateTime.Now;

            foreach (var vacation in _events)
            {
                vacationsCalendar.RemoveEvent(vacation);
            }
            _events.Clear();
            _vacations.Clear();

            var response = await ApiHelper.Instance.GetMeVacationsAsync();

            if (response != null)
            {
                _vacations = response.ToList();

                foreach (var vacation in response)
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

            int freeVacations = _numberOfVacations - _vacations.Where(x => x.Approved).Count();
            vacationsCountLabel.Text = (freeVacations <= 0) ? "0" : freeVacations.ToString();
            vacationsCountLabel.Visible = true;
        }

        private async void planVacationButton_ClickAsync(object sender, EventArgs e)
        {
            if (int.Parse(vacationsCountLabel.Text) == 0 && CurrentUser.User.Role == Role.WorkPlaceLeader)
            {
                errorLabel.Text = "There are no free vacations left";
                return;
            }

            if (planVacationTextBox.Text == "")
            {
                errorLabel.Text = "Reason is empty";
                return;
            }

            if (vacationDateTimePicker.Value < DateTime.Now)
            {
                errorLabel.Text = "Date is in the past";
                return;
            }

            var result = await ApiHelper.Instance.AddVacationAsync(vacationDateTimePicker.Value.Date, planVacationTextBox.Text);

            if (result.Success == false)
            {
                errorLabel.Text = "";
                foreach (var error in result.Errors)
                {
                    errorLabel.Text += error;
                }
            }
            else
            {
                planVacationTextBox.Text = "";
                vacationDateTimePicker.Value = DateTime.Now;
                errorLabel.Text = "Vacation planned successfuly";
                await LoadDataAsync();
            }
        }

        private async void cancelVacationButton_ClickAsync(object sender, EventArgs e)
        {
            if (vacationDateTimePicker.Value < DateTime.Now)
            {
                errorLabel.Text = "Date is in the past";
                return;
            }

            var result = await ApiHelper.Instance.RemoveVacationAsync(vacationDateTimePicker.Value.Date);

            if (result.Success == true)
            {
                vacationDateTimePicker.Value = DateTime.Now;
                errorLabel.Text = "Vacation cancelled successfuly";
                await LoadDataAsync();
                return;
            }

            errorLabel.Text = result.ErrorMessage;
        }

        private async void VacationsScreen_LoadAsync(object sender, EventArgs e)
        {
            _numberOfVacations = (await ApiHelper.Instance.GetMeAsync()).Data.NumberOfVacationDays;
            await LoadDataAsync();
        }

        private void errorLabel_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = true;
        }
    }
}
