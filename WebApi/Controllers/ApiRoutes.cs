namespace WebApi.Controllers
{
    public static class ApiRoutes
    {
        private const string _base = "api/";

        public static class Employees
        {
            public const string HireEmployee = _base + "employees/{candidateId}";
            public const string GetEmployee = _base + "employees/employee";
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

        public static class Documentation
        {
            public const string CreateDocumentForEmployee = _base + "documentation/{employeeId}";
            public const string CreateDocumentForCandidate = _base + "documentation/{candidateId}";
            public const string DeleteDocument = _base + "documentation/{documentId}";
            public const string GetAllDocumentsOfEmployee = _base + "documentation/employee/{employeeId}";
            public const string GetAllDocumentsOfCandidate = _base + "documentation/candidate/{candidateId}";
            public const string GetAllDocumentsOfFormerEmployee = _base + "documentation/formerEmployee/{formerEmployeeId}";
            public const string GetDocument = _base + "documentation/{documentId}";
        }

        public static class Equipment
        {
            public const string CreateEquipment = _base + "equipment/{employeeId}";
            public const string DeleteEquipment = _base + "equipment/{equipmentId}";
            public const string GetAllEquipmentOfEmployee = _base + "equipment/employee";
            public const string GetEquipmentStatusOfEmployee = _base + "equipment/employee/status";
            public const string SetEquipmentStatusOfEmployee = _base + "equipment/{employeeId}/status";
        }

        public static class Specialties
        {
            public const string CreateSpecialty = _base + "specialties/{workPlaceId}";
            public const string DeleteSpecialty = _base + "specialties/{specialtyId}";
            public const string GetAllSpecialtesOfWorkPlace = _base + "specialties/{workPlaceId}";
        }

        public static class Evaluations
        {
            public const string CreateEvaluation = _base + "evaluations/{employeeId}/{hR_WorkerId}";
            public const string DeleteEvaluation = _base + "evaluations/{evaluationId}";
            public const string GetAllEvaluationsOfEmployee = _base + "evaluations/{employeeId}";
        }

        public static class Bonuses
        {
            public const string CreateBonus = _base + "bonuses/{employeeId}/{hR_WorkerId}";
            public const string DeleteBonus = _base + "bonuses/{bonusId}";
            public const string GetAllBonusesOfEmployee = _base + "bonuses/employee";
        }

        public static class Vacations
        {
            public const string CreateVacation = _base + "vacations/";
            public const string DeleteVacation = _base + "vacations/{dateAndTime}";
            public const string GetAllVacationsOfEmployee = _base + "vacations/employee";
            public const string GetAllVacationsOfSelectedEmployee = _base + "vacations/{employeeId}";
            public const string SetApprovedStateOfVacation = _base + "vacations/{vacationId}";
        }

        public static class CorporateEvents
        {

            public const string CreateCorporateEvent = _base + "corporateEvents";
            public const string DeleteCorporateEvent = _base + "corporateEvents/{corporateEventId}";
            public const string EditCorporateEvent = _base + "corporateEvents/{corporateEventId}";
            public const string GetAllCorporateEvents = _base + "corporateEvents";
            public const string GetCorporateEvent = _base + "corporateEvents/{corporateEventId}";
            public const string AssignEmployeesToCorporateEvent = _base + "corporateEvents/employees/{corporateEventId}";
            public const string AssignWorkPlaceLeadersToCorporateEvent = _base + "corporateEvents/workPlaceLeaders/{corporateEventId}";
            public const string GetAllCorporateEventsOfEmployee = _base + "corporateEvents/employee";
        }
    }
}
