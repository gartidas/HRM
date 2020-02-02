using System.Collections.Generic;

namespace WebApi.Paging
{
    public class PagingResponse<T>
    {
        public PagingResponse() { }

        public PagingResponse(IList<T> data)
        {
            Data = data;
        }

        public IList<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int Pages { get; set; }
    }
}
