using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.UserControls.FeatureScreens
{
    public partial class CorporateEventsScreen : UserControl
    {
        private List<CustomEvent> _events = new List<CustomEvent>();

        public CorporateEventsScreen()
        {
            InitializeComponent();
        }

        public async Task LoadDataAsync()
        {
            corporateEventsCalendar.LoadPresetHolidays = false;
            corporateEventsCalendar.AllowEditingEvents = false;
            corporateEventsCalendar.CalendarDate = DateTime.Now;

            foreach (var corpEvent in _events)
            {
                corporateEventsCalendar.RemoveEvent(corpEvent);
            }
            _events.Clear();

            var response = await ApiHelper.Instance.GetEmployeeCorporateEventsAsync();

            if (response != null)
            {
                foreach (var corpEvent in response)
                {
                    var newCorpEvent = new CustomEvent
                    {
                        Date = corpEvent.DateAndTime,
                        EventColor = (corpEvent.DateAndTime > DateTime.Now.Date) ? Color.White : Color.DarkGray,
                        EventTextColor = (corpEvent.DateAndTime > DateTime.Now.Date) ? Color.Black : Color.Gray,
                        EventText = $@"Name: {corpEvent.Name}
Location: {corpEvent.Location}",
                        IgnoreTimeComponent = true
                    };

                    _events.Add(newCorpEvent);
                    corporateEventsCalendar.AddEvent(newCorpEvent);
                }
            }
        }

        private async void CorporateEventsScreen_LoadAsync(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
