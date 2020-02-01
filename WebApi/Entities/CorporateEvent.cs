using System;
using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class CorporateEvent
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string RequestDescription { get; set; }
        public string Location { get; set; }
        public DateTime DateAndTime { get; set; }
        public List<EmployeeCorporateEvent> EmployeeCorporateEvent { get; set; }
        public List<WorkPlaceLeaderCorporateEvent> WorkPlaceLeaderCorporateEvent { get; set; }
    }
}
