namespace WebApi.Controllers
{
    public static class ApiRoutes
    {
        private const string _base = "api/";

        public static class Identity
        {
            public const string Register = _base + "identity/register";
            public const string Login = _base + "identity/login";
        }

        public static class Users
        {
            public const string GetAllUsers = _base + "users";
            public const string GetUser = _base + "users/{userId}";
            public const string DeleteUser = _base + "users/{userId}";
            public const string EditUser = _base + "users/{userId}";
        }

        public static class Me
        {
            public const string ChangePassword = _base + "me/password";
        }

    }
}
