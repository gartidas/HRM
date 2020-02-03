using System.Collections.Generic;

namespace WebApi.Paging
{
    public class PagingResponse<T>
    {
        public PagingResponse() { }

        public PagingResponse(IEnumerable<T> content)
        {
            Content = content;
        }

        public IEnumerable<T> Content { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int Pages { get; set; }
    }
}
