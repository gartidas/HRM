using System;

namespace WebApi.Entities
{
    public class Bonus
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime GrantedDate { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeID { get; set; }
        public HR_Worker HR_Worker { get; set; }
        public string HR_WorkerID { get; set; }
    }
}
