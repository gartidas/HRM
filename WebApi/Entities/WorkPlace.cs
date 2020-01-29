using System.Collections.Generic;

namespace WebApi.Entities
{
    public class WorkPlace
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public string Location { get; set; }
        public int LeadByID { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Specialty> Specialties { get; set; }

    }
}
