using System;

namespace WebApi.Entities
{
    public class Bonus
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime GrantedDate { get; set; }
        public int GrantedByID { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
    }
}
