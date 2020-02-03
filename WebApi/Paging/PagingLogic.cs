﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Paging
{
    public class PagingLogic
    {
        public static async Task<PagingResponse<TResponseDto>> GetPagedContent<TResponseDto, TEntity>
            (IQueryable<TEntity> content, PagingReferences references, Func<TEntity, TResponseDto> mapper, CancellationToken cancellationToken)
        {
            var skipSize = (references.PageNumber - 1) * references.PageSize;

            var pagedContent = (await content.Skip(skipSize).Take(references.PageSize).ToListAsync(cancellationToken)).Select(mapper);

            return new PagingResponse<TResponseDto>(pagedContent)
            {
                PageNumber = references.PageNumber,
                Pages = (int)Math.Ceiling((decimal)content.Count() / references.PageSize),
                PageSize = references.PageSize
            };
        }

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
