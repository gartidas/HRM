using System;

namespace WebApi.Entities
{
    public class Vacation
    {
        public int ID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }
        public int ApprovedBy { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
