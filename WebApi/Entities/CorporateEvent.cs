using System;
using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class CorporateEvent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RequestDescription { get; set; }
        public string Location { get; set; }
        public DateTime DateAndTime { get; set; }
        public int GrantedByID { get; set; }
        public List<EmployeeCorporateEvent> EmployeeCorporateEvent { get; set; }
    }
}
