using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class Employee
    {
        public string ID { get; set; }
        public ApplicationUser IdentityUser
        {
            get => _identityUser;
            set
            {
                if (value != null) ID = value.Id;
                _identityUser = value;
            }
        }
        public bool HasChangedRole { get; set; }

        private ApplicationUser _identityUser;
        public WorkPlace WorkPlace { get; set; }
        public string WorkPlaceID { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Evaluation> Evaluations { get; set; }
        public List<Document> Documentation { get; set; }
        public List<Vacation> Vacations { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<EmployeeCorporateEvent> EmployeeCorporateEvent { get; set; }
    }
}
