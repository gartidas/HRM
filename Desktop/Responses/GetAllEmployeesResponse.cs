using Desktop.Models;
using System.Collections.Generic;

namespace Desktop.Responses
{
    class GetAllEmployeesResponse
    {
        public IEnumerable<Employee> Content { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
    }
}
