using System.Collections.Generic;

namespace WebApi.Domain.IdentityModels
{
    public class AuthenticationResult
    {
        public string Token { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Success { get; set; }
        public string UserRole { get; set; }
    }
}
