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
            public const string FireEmployee = _base + "employees/{employeeId}";
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

        public static class FormerEmployees
        {
            public const string GetFormerEmployee = _base + "formerEmployees/{formerEmployeeId}";
            public const string GetAllFormerEmployees = _base + "formerEmployees";
            public const string DeleteFormerEmployee = _base + "formerEmployees/{formerEmployeeId}";
        }

        public static class WorkPlaces
        {
            public const string CreateWorkPlace = _base + "workPlaces";
            public const string GetWorkPlace = _base + "workPlaces/{workPlaceId}";
            public const string GetAllWorkPlaces = _base + "workPlaces";
            public const string EditWorkPlace = _base + "workPlaces/{workPlaceId}";
            public const string DeleteWorkPlace = _base + "workPlaces/{workPlaceId}";
        }
    }
}
