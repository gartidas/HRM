namespace WebApi.Controllers
{
    public static class ApiRoutes
    {
        private const string _base = "api/";

        public static class Employees
        {
            public const string HireEmployee = _base + "employees/{candidateId}";
            public const string GetEmployee = _base + "employees/{employeeId}";
            public const string GetAllEmployees = _base + "employees";
            public const string EditEmployee = _base + "employees/{employeeId}";
        }

        public static class Users
        {
            public const string Login = _base + "users/login";
            public const string ChangePassword = _base + "users/password";
        }
        public static class Candidates
        {
            public const string GetAllCandidates = _base + "candidates";
            public const string GetCandidate = _base + "candidates/{candidateId}";
            public const string CreateCandidate = _base + "candidates";
            public const string DeleteCandidate = _base + "candidates/{candidateId}";
            public const string EditCandidate = _base + "candidates/{candidateId}";
        }
    }
}
