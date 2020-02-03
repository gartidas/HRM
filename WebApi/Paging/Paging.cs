using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Paging
{
    public class Paging
    {
        public static PagingResponse<T> GetPagedContent<T>(IEnumerable<T> content, PagingReferences references)
        {
            var skipSize = (references.PageNumber - 1) * references.PageSize;

            var pagedContent = content.Skip(skipSize).Take(references.PageSize).ToList();

            return new PagingResponse<T>(pagedContent)
            {
                PageNumber = references.PageNumber,
                Pages = (int)Math.Ceiling((decimal)content.Count() / references.PageSize),
                PageSize = references.PageSize
            };
        }
    }
}
