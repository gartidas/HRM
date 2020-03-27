using System;

namespace Desktop.Models
{
    class Bonus
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public DateTime GrantedDate { get; set; }
        public HR_Worker HR_Worker { get; set; }
    }
}
