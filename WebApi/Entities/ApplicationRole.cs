using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WebApi.Entities.Joins;

namespace WebApi.Entities
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole(string name)
        {
            Name = name;
        }

        public List<UserRole> UserRole { get; set; }
    }
}
