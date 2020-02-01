using System;

namespace WebApi.Entities
{
    public class Vacation
    {
        public string ID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeID { get; set; }
    }
}
