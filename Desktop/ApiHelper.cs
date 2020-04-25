using Desktop.Models;
using Desktop.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    class ApiHelper
    {
        public static ApiHelper Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new ApiHelper();
                return _instance;
            }
        }

        private static ApiHelper _instance = new ApiHelper();
        private HttpClient _client = new HttpClient();
        private bool _doingStuff;

        public bool DoingStuff
        {
            get { return _doingStuff; }
            set
            {
                _doingStuff = value;
                if (_doingStuff == true)
                {
                    LoadingPictureBox.Visible = true;
                }
                else
                {
                    LoadingPictureBox.Visible = false;
                }
            }
        }

        public PictureBox LoadingPictureBox { get; set; }

        private ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Api"]);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/problem+json"));
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var data = new
            {
                email,
                password
            };

            var response = await _client.PostAsJsonAsync("users/login", data);
            var loginresponse = await response.Content.ReadAsAsync<LoginResponse>();

            if (loginresponse.Success)
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginresponse.Token}");

            return loginresponse;
        }

        public void LogoutUser()
        {
            _client.DefaultRequestHeaders.Remove("Authorization");
            CurrentUser.User.ClearUser();
        }

        public async Task<GenericResponse> ChangePasswordAsync(string currentPassword, string newPassword)
        {
            DoingStuff = true;
            var data = new
            {
                currentPassword,
                newPassword
            };

            var response = await _client.PostAsJsonAsync("users/password", data);
            var content = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return content;
        }

        public async Task<Employee> GetEmployeeDataAsync()
        {
            DoingStuff = true;
            Employee employee = null;

            var response = await _client.GetAsync("employees/employee");

            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }

            DoingStuff = false;
            return employee;
        }

        public async Task<IEnumerable<Vacation>> GetEmployeeVacationsAsync()
        {
            DoingStuff = true;
            IEnumerable<Vacation> vacations = null;

            var response = await _client.GetAsync("vacations/employee");

            if (response.IsSuccessStatusCode)
            {
                vacations = await response.Content.ReadAsAsync<IEnumerable<Vacation>>();
            }

            DoingStuff = false;
            return vacations;
        }

        public async Task<GenericResponse> AddVacationAsync(DateTime dateAndTime, string reason)
        {
            DoingStuff = true;
            var data = new
            {
                dateAndTime,
                reason
            };

            var response = await _client.PostAsJsonAsync("vacations/", data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<AlternativeGenericResponse> DeleteVacationAsync(DateTime dateAndTime)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("vacations/" + dateAndTime.ToString());

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Event>> GetEmployeeCorporateEventsAsync()
        {
            DoingStuff = true;
            IEnumerable<Event> events = null;

            var response = await _client.GetAsync("corporateEvents/employee");

            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
            }

            DoingStuff = false;
            return events;
        }

        public async Task<IEnumerable<Evaluation>> GetEmployeeEvaluationsAsync()
        {
            DoingStuff = true;
            IEnumerable<Evaluation> evaluations = null;

            var response = await _client.GetAsync("evaluations/employee");

            if (response.IsSuccessStatusCode)
            {
                evaluations = await response.Content.ReadAsAsync<IEnumerable<Evaluation>>();
            }

            DoingStuff = false;
            return evaluations;
        }

        public async Task<IEnumerable<Bonus>> GetEmployeeBonusesAsync()
        {
            DoingStuff = true;
            IEnumerable<Bonus> bonuses = null;

            var response = await _client.GetAsync("bonuses/employee");

            if (response.IsSuccessStatusCode)
            {
                bonuses = await response.Content.ReadAsAsync<IEnumerable<Bonus>>();
            }

            DoingStuff = false;
            return bonuses;
        }

        public async Task<IEnumerable<EquipmentItem>> GetEmployeeEquipmentAsync()
        {
            DoingStuff = true;
            IEnumerable<EquipmentItem> items = null;

            var response = await _client.GetAsync("equipment/employee");

            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<IEnumerable<EquipmentItem>>();
            }

            DoingStuff = false;
            return items;
        }

        public async Task<EquipmentStatus> GetEmployeeEquipmentStatusAsync()
        {
            DoingStuff = true;
            EquipmentStatus status = default;

            var response = await _client.GetAsync("equipment/employee/status");

            if (response.IsSuccessStatusCode)
            {
                status = (EquipmentStatus)(await response.Content.ReadAsAsync<int>());
            }

            DoingStuff = false;
            return status;
        }

        public async Task<GenericGetAllResponse<Employee>> GetAllEmployeesAsync(int pageNumber = 1, int pageSize = 11, string specialtyFilter = "", string emailFilter = "", string surnameFilter = "", string roleFilter = "", string workPlaceIdFilter = "")
        {
            DoingStuff = true;

            var response = await _client.GetAsync($"employees?PageNumber={pageNumber}&PageSize={pageSize}&Email={emailFilter}&Role={roleFilter}&Specialty={specialtyFilter}&Surname={surnameFilter}&WorkPlaceId={workPlaceIdFilter}");
            var result = await response.Content.ReadAsAsync<GenericGetAllResponse<Employee>>();

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Vacation>> GetSelectedEmployeeVacationsAsync(string employeeId)
        {
            DoingStuff = true;
            IEnumerable<Vacation> vacations = null;

            var response = await _client.GetAsync($"vacations/" + employeeId);

            if (response.IsSuccessStatusCode)
            {
                vacations = await response.Content.ReadAsAsync<IEnumerable<Vacation>>();
            }

            DoingStuff = false;
            return vacations;
        }

        public async Task<GenericResponse> SetEmployeeVacationApprovedStateAsync(string vacationId, bool approved)
        {
            DoingStuff = true;

            var data = new
            {
                approved
            };

            var response = await _client.PutAsJsonAsync("vacations/" + vacationId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Specialty>> GetAllSpecialtiesOfWorkplaceAsync(string workPlaceId)
        {
            DoingStuff = true;
            IEnumerable<Specialty> specialties = null;

            var response = await _client.GetAsync("specialties/" + workPlaceId);

            if (response.IsSuccessStatusCode)
            {
                specialties = await response.Content.ReadAsAsync<IEnumerable<Specialty>>();
            }

            DoingStuff = false;
            return specialties;
        }

        public async Task<GenericResponse> AddSpecialtyOfWorkPlaceAsync(string workPlaceId, string name, int numberOfEmployees)
        {
            DoingStuff = true;
            bool type = true;
            var data = new
            {
                name,
                numberOfEmployees,
                type
            };

            var response = await _client.PostAsJsonAsync("specialties/" + workPlaceId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<AlternativeGenericResponse> DeleteSpecialtyOfWorkPlaceAsync(string workPlaceId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("specialties/" + workPlaceId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Event>> GetCorporateEventsOfWorkPlaceAsync()
        {
            DoingStuff = true;
            IEnumerable<Event> events = null;

            var response = await _client.GetAsync("corporateEvents/workPlace");

            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
            }

            DoingStuff = false;
            return events;
        }

        public async Task<Event> GetCorporateEventAsync(string eventId)
        {
            DoingStuff = true;
            Event corpEvent = null;

            var response = await _client.GetAsync("corporateEvents/" + eventId);

            if (response.IsSuccessStatusCode)
            {
                corpEvent = await response.Content.ReadAsAsync<Event>();
            }

            DoingStuff = false;
            return corpEvent;
        }

        public async Task<GenericResponse> AssignEmployeeToCorporateEventAsync(string corporateEventId, string employeeId)
        {
            DoingStuff = true;
            IEnumerable<string> employeeIds = new List<string>() { employeeId };

            var data = new
            {
                employeeIds
            };

            var response = await _client.PutAsJsonAsync("corporateEvents/employees/assign/" + corporateEventId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> RemoveEmployeeFromCorporateEventAsync(string corporateEventId, string employeeId)
        {
            DoingStuff = true;
            IEnumerable<string> employeeIds = new List<string>() { employeeId };

            var data = new
            {
                employeeIds
            };

            var response = await _client.PutAsJsonAsync("corporateEvents/employees/remove/" + corporateEventId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsOfEmployeeAsync(string employeeId)
        {
            DoingStuff = true;
            IEnumerable<Evaluation> evaluations = null;

            var response = await _client.GetAsync("evaluations/" + employeeId);

            if (response.IsSuccessStatusCode)
            {
                evaluations = await response.Content.ReadAsAsync<IEnumerable<Evaluation>>();
            }

            DoingStuff = false;
            return evaluations;
        }

        public async Task<GenericGetAllResponse<Candidate>> GetAllCandidates(int pageNumber = 1, int pageSize = 11, string specialtyFilter = "", string emailFilter = "", string surnameFilter = "", bool hiredFilter = false)
        {
            DoingStuff = true;

            var response = await _client.GetAsync($"candidates?PageNumber={pageNumber}&PageSize={pageSize}&Hired={hiredFilter}&Email={emailFilter}&Specialty={specialtyFilter}&Surname={surnameFilter}");
            var result = await response.Content.ReadAsAsync<GenericGetAllResponse<Candidate>>();

            DoingStuff = false;
            return result;
        }

        public async Task<Candidate> GetSelectedCandidate(string candidateId)
        {
            DoingStuff = true;
            Candidate candidate = null;

            var response = await _client.GetAsync("candidates/" + candidateId);

            if (response.IsSuccessStatusCode)
            {
                candidate = await response.Content.ReadAsAsync<Candidate>();
            }

            DoingStuff = false;
            return candidate;
        }

        public async Task<GenericResponse> AddCandidateAsync(string title, string name, string surname, string education, string specialty, string phoneNumber, string email, string address, double requestedSalary, int evaluation, Status status, string additionalInfo)
        {
            DoingStuff = true;
            var data = new
            {
                title,
                name,
                surname,
                education,
                specialty,
                phoneNumber,
                email,
                address,
                requestedSalary,
                evaluation,
                status,
                additionalInfo
            };

            var response = await _client.PostAsJsonAsync("candidates/", data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> EditCandidateAsync(string candidateId, string title, string name, string surname, string education, string specialty, string phoneNumber, string email, string address, double requestedSalary, int evaluation, Status status, string additionalInfo)
        {
            DoingStuff = true;
            var data = new
            {
                title,
                name,
                surname,
                education,
                specialty,
                phoneNumber,
                email,
                address,
                requestedSalary,
                evaluation,
                status,
                additionalInfo
            };

            var response = await _client.PutAsJsonAsync("candidates/" + candidateId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<AlternativeGenericResponse> RemoveCandidateAsync(string candidateId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("candidates/" + candidateId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<Employee> GetSelectedEmployeeDataAsync(string employeeId)
        {
            DoingStuff = true;
            Employee employee = null;

            var response = await _client.GetAsync("employees/" + employeeId);

            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }

            DoingStuff = false;
            return employee;
        }


        public async Task<List<Document>> GetAllDocumentsOfCandidateAsync(string candidateId)
        {
            DoingStuff = true;
            List<Document> documents = null;

            var response = await _client.GetAsync(" documentation/candidate/" + candidateId);

            if (response.IsSuccessStatusCode)
            {
                documents = await response.Content.ReadAsAsync<List<Document>>();
            }

            DoingStuff = false;
            return documents;
        }

        public async Task<GenericResponse> CreateDocumentAsync(string subjectType, string subjectId, byte[] content, string name)
        {
            DoingStuff = true;
            var data = new
            {
                name,
                content
            };

            var response = await _client.PostAsJsonAsync("documentation/" + subjectType + "/" + subjectId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<AlternativeGenericResponse> RemoveDocumentAsync(string documentId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("documentation/" + documentId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<GenericGetAllResponse<EmployeeWorkPlaceData>> GetAllWorkPlacesAsync(int pageNumber = 1, int pageSize = 11, string labelFilter = "", string locationFilter = "")
        {
            DoingStuff = true;

            var response = await _client.GetAsync($"workPlaces?PageNumber={pageNumber}&PageSize={pageSize}&Label={labelFilter}&Location={locationFilter}");
            var result = await response.Content.ReadAsAsync<GenericGetAllResponse<EmployeeWorkPlaceData>>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> HireEmployeeAsync(string candidateId, string password, string birthCertificateNumber, DateTime birthDate, string birthPlace, string citizenship, bool gender, double salary, int numberOfVacationDays, string workPlaceID, Role role, string idCardNumber, string drivingLicenceNumber, string healthInsuranceCompany, int numberOfChildren, FamilyStatus familyStatus, string nameOfTheBank, string accountNumber)
        {
            DoingStuff = true;
            var data = new
            {
                password,
                birthCertificateNumber,
                birthDate,
                birthPlace,
                citizenship,
                gender,
                salary,
                numberOfVacationDays,
                workPlaceID,
                role,
                idCardNumber,
                drivingLicenceNumber,
                healthInsuranceCompany,
                numberOfChildren,
                familyStatus,
                nameOfTheBank,
                accountNumber
            };

            var response = await _client.PostAsJsonAsync("employees/hire/" + candidateId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> FireEmployeeAsync(string employeeId, string terminationReason, DateTime terminationDate)
        {
            DoingStuff = true;
            var data = new
            {
                terminationReason,
                terminationDate
            };

            var response = await _client.PostAsJsonAsync("employees/fire/" + employeeId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<List<Document>> GetAllDocumentsOfEmployeeAsync(string employeeId)
        {
            DoingStuff = true;
            List<Document> documents = null;

            var response = await _client.GetAsync(" documentation/employee/" + employeeId);

            if (response.IsSuccessStatusCode)
            {
                documents = await response.Content.ReadAsAsync<List<Document>>();
            }

            DoingStuff = false;
            return documents;
        }

        public async Task<GenericResponse> EditEmployeeAsync(string employeeId, string title, string name, string surname, string emailAddress, string phoneNumber, string specialty, string addressOfPermanentResidence, string birthCertificateNumber, DateTime birthDate, string birthPlace, string citizenship, bool gender, double salary, int numberOfVacationDays, string workPlaceID, Role role, string idCardNumber, string drivingLicenceNumber, string healthInsuranceCompany, int numberOfChildren, FamilyStatus familyStatus, string nameOfTheBank, string accountNumber)
        {
            DoingStuff = true;
            var data = new
            {
                title,
                name,
                surname,
                emailAddress,
                phoneNumber,
                birthCertificateNumber,
                birthDate,
                birthPlace,
                specialty,
                addressOfPermanentResidence,
                citizenship,
                gender,
                salary,
                numberOfVacationDays,
                workPlaceID,
                role,
                idCardNumber,
                drivingLicenceNumber,
                healthInsuranceCompany,
                numberOfChildren,
                familyStatus,
                nameOfTheBank,
                accountNumber
            };

            var response = await _client.PutAsJsonAsync("employees/" + employeeId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericGetAllResponse<FormerEmployee>> GetAllFormerEmployeesAsync(int pageNumber = 1, int pageSize = 11, string specialtyFilter = "", string emailFilter = "", string surnameFilter = "", string roleFilter = "")
        {
            DoingStuff = true;

            var response = await _client.GetAsync($"formerEmployees?PageNumber={pageNumber}&PageSize={pageSize}&Email={emailFilter}&Role={roleFilter}&Specialty={specialtyFilter}&Surname={surnameFilter}");
            var result = await response.Content.ReadAsAsync<GenericGetAllResponse<FormerEmployee>>();

            DoingStuff = false;
            return result;
        }

        public async Task<FormerEmployee> GetSelectedFormerEmployeeAsync(string formerEmployeeId)
        {
            DoingStuff = true;
            FormerEmployee employee = null;

            var response = await _client.GetAsync("formerEmployees/" + formerEmployeeId);

            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<FormerEmployee>();
            }

            DoingStuff = false;
            return employee;
        }

        public async Task<AlternativeGenericResponse> RemoveFormerEmployeeAsync(string formerEmployeeId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("formerEmployees/" + formerEmployeeId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<List<Document>> GetAllDocumentsOfFormerEmployeeAsync(string formerEmployeeId)
        {
            DoingStuff = true;
            List<Document> documents = null;

            var response = await _client.GetAsync("documentation/formerEmployee/" + formerEmployeeId);

            if (response.IsSuccessStatusCode)
            {
                documents = await response.Content.ReadAsAsync<List<Document>>();
            }

            DoingStuff = false;
            return documents;
        }

        public async Task<GenericGetAllResponse<Event>> GetAllCorporateEventsAsync(int pageNumber = 1, int pageSize = 11, string nameFilter = "", string locationFilter = "")
        {
            DoingStuff = true;

            var response = await _client.GetAsync($"corporateEvents?PageNumber={pageNumber}&PageSize={pageSize}&Name={nameFilter}&Location={locationFilter}");
            var result = await response.Content.ReadAsAsync<GenericGetAllResponse<Event>>();

            DoingStuff = false;
            return result;
        }

        public async Task<AlternativeGenericResponse> RemoveCorporateEventAsync(string corporateEventId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("corporateEvents/" + corporateEventId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> AssignWorkPlaceLeaderToCorporateEventAsync(string corporateEventId, string workPlaceLeaderId)
        {
            DoingStuff = true;
            IEnumerable<string> workPlaceLeaderIds = new List<string>() { workPlaceLeaderId };

            var data = new
            {
                workPlaceLeaderIds
            };

            var response = await _client.PutAsJsonAsync("corporateEvents/workPlaceLeaders/assign/" + corporateEventId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> RemoveWorkPlaceLeaderFromCorporateEventAsync(string corporateEventId, string workPlaceLeaderId)
        {
            DoingStuff = true;
            IEnumerable<string> workPlaceLeaderIds = new List<string>() { workPlaceLeaderId };

            var data = new
            {
                workPlaceLeaderIds
            };

            var response = await _client.PutAsJsonAsync("corporateEvents/workPlaceLeaders/remove/" + corporateEventId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> AddCorporateEventAsync(string name, string location, DateTime dateAndTime, string requestDescription)
        {
            DoingStuff = true;
            var data = new
            {
                name,
                location,
                dateAndTime,
                requestDescription
            };

            var response = await _client.PostAsJsonAsync("corporateEvents/", data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> EditCorporateEventAsync(string corporateEventId, string name, string location, DateTime dateAndTime, string requestDescription)
        {
            DoingStuff = true;
            var data = new
            {
                name,
                location,
                dateAndTime,
                requestDescription
            };

            var response = await _client.PutAsJsonAsync("corporateEvents/" + corporateEventId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }

        public async Task<IEnumerable<Bonus>> GetBonusesOfSelectedEmployeeAsync(string employeeId)
        {
            DoingStuff = true;
            IEnumerable<Bonus> bonuses = null;

            var response = await _client.GetAsync("bonuses/" + employeeId);

            if (response.IsSuccessStatusCode)
            {
                bonuses = await response.Content.ReadAsAsync<IEnumerable<Bonus>>();
            }

            DoingStuff = false;
            return bonuses;
        }

        public async Task<AlternativeGenericResponse> RemoveBonusAsync(string bonusId)
        {
            DoingStuff = true;
            var response = await _client.DeleteAsync("bonuses/" + bonusId);

            if (response.IsSuccessStatusCode) return new AlternativeGenericResponse { Success = true };

            var message = await response.Content.ReadAsAsync<string>();
            var result = new AlternativeGenericResponse { ErrorMessage = message };

            DoingStuff = false;
            return result;
        }

        public async Task<GenericResponse> AddBonusForEmployeeAsync(string employeeId, string hR_WorkerId, DateTime grantedDate, int value, string description)
        {
            DoingStuff = true;
            var data = new
            {
                hR_WorkerId,
                description,
                value,
                grantedDate
            };

            var response = await _client.PostAsJsonAsync("bonuses/" + employeeId, data);
            var result = await response.Content.ReadAsAsync<GenericResponse>();

            DoingStuff = false;
            return result;
        }
    }
}
