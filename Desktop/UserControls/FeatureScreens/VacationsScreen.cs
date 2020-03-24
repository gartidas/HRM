using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens
{
    public partial class VacationsScreen : UserControl
    {
        //source: https://www.codeproject.com/Articles/378900/Calendar-NET

        private List<CustomEvent> _events = new List<CustomEvent>();

        public VacationsScreen()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            vacationsCalendar.LoadPresetHolidays = false;
            vacationsCalendar.AllowEditingEvents = false;
            vacationsCalendar.CalendarDate = DateTime.Now;

            foreach (var vacation in _events)
            {
                vacationsCalendar.RemoveEvent(vacation);
            }
            _events.Clear();

            var response = await ApiHelper.Instance.GetEmployeeVacationsAsync();

            if (response != null)
            {
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
        }

        private async void planVacationButton_ClickAsync(object sender, EventArgs e)
        {
            if (planVacationTextBox.Text == "")
            {
                errorLabel.Text = "Reason is empty";
                errorLabel.Visible = true;
                return;
            }

            if (vacationDateTimePicker.Value < DateTime.Now)
            {
                errorLabel.Text = "Date is in the past";
                errorLabel.Visible = true;
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
                errorLabel.Visible = true;
            }
            else
            {
                planVacationTextBox.Text = "";
                vacationDateTimePicker.Value = DateTime.Now;
                errorLabel.Text = "Vacation planned successfuly";
                errorLabel.Visible = true;
                LoadDataAsync();
            }
        }

        private async void cancelVacationButton_ClickAsync(object sender, EventArgs e)
        {
            if (vacationDateTimePicker.Value < DateTime.Now)
            {
                errorLabel.Text = "Date is in the past";
                errorLabel.Visible = true;
                return;
            }

            var result = await ApiHelper.Instance.DeleteVacationAsync(vacationDateTimePicker.Value.Date);

            if (result.Success == true)
            {
                vacationDateTimePicker.Value = DateTime.Now;
                errorLabel.Text = "Vacation cancelled successfuly";
                errorLabel.Visible = true;
                LoadDataAsync();
            }
            else
            {
                errorLabel.Text = result.ErrorMessage;
                errorLabel.Visible = true;
            }
        }
    }
}
