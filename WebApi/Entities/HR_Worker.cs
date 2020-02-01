using System.Collections.Generic;

namespace WebApi.Entities
{
    public class HR_Worker
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
        public List<Evaluation> Evaluations { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<FormerEmployee> FormerEmployees { get; set; }
    }
}
