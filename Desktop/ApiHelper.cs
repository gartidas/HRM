using Desktop.Models;
using Desktop.Responses;
using Desktop.Responses.ModelResponses;
using System;
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

        public async Task<GetEmployeeResponse> GetEmployeeAsync()
        {
            DoingStuff = true;
            GetEmployeeResponse employee = null;

            var response = await _client.GetAsync("employee/");

            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<GetEmployeeResponse>();
            }

            DoingStuff = false;
            return employee;
        }
    }
}
