﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class GetAllDocumentsOfEmployee
    {
        public class Query : IRequest<IQueryable<GetDocument.DocumentDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<GetDocument.DocumentDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<GetDocument.DocumentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var documents = _context.Documents.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<GetDocument.DocumentDto>(_mapper.ConfigurationProvider);
                return await Task.FromResult(documents); ;
            }
        }
    }

}
