using Microsoft.AspNetCore.Identity;

namespace WebApi.Entities
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}
