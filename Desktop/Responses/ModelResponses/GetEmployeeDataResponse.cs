using Desktop.Responses.ModelResponses.Models;

namespace Desktop.Responses.ModelResponses
{
    class GetEmployeeDataResponse
    {
        public string ID { get; set; }
        public EmployeeData Data { get; set; }
        public EmployeeWorkPlaceData WorkPlace { get; set; }
    }
}
