using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class WorkPlaceLeader
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
        public List<WorkPlaceLeaderCorporateEvent> WorkPlaceLeaderCorporateEvent { get; set; }
    }
}
