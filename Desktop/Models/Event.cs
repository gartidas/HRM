using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    class Event
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateAndTime { get; set; }
        public string RequestDescription { get; set; }
        public List<CorporateEventSubject> InvitedWorkPlaceLeaders { get; set; }
        public List<CorporateEventSubject> InvitedEmployees { get; set; }
    }
}
