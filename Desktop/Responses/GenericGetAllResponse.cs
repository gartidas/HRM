using System.Collections.Generic;

namespace Desktop.Responses
{
    class GenericGetAllResponse<T>
    {
        public IEnumerable<T> Content { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
    }
}
