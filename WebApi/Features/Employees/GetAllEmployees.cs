using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Paging;
using static WebApi.Features.Employees.GetEmployee;

namespace WebApi.Features.Employees
{
    public class GetAllEmployees
    {
        public class Query : IRequest<PagingResponse<EmployeeDto>>
        {
            public Filter Filter { get; set; }
            public PagingReferences PagingReferences { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PagingResponse<EmployeeDto>>
        {
            private Context _context;
            private IMapper _mapper;
            private UserManager<ApplicationUser> _userManager;

            public QueryHandler(Context context, IMapper mapper, UserManager<ApplicationUser> userManager)
            {
                _context = context;
                _mapper = mapper;
                _userManager = userManager;
            }

            public async Task<PagingResponse<EmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employeeDtos = _context.Employees.ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToList();

                for (int i = 0; i < employeeDtos.Count(); i++)
                {
                    var employee = await _userManager.FindByIdAsync(employeeDtos[i].ID);
                    employeeDtos[i].Data = _mapper.Map<EmployeeData>(employee);
                    employeeDtos[i].Data.Role = (await _userManager.GetRolesAsync(employee)).Single();
                }
                employeeDtos = ApplyFiltering(request.Filter, employeeDtos).OrderBy(x => x.Data.Surname).ThenBy(x => x.Data.Name).ThenBy(x => x.Data.Specialty).ToList();

                return PagingLogic.GetPagedContent(employeeDtos, request.PagingReferences);
            }

            private IEnumerable<EmployeeDto> ApplyFiltering(Filter filter, IEnumerable<EmployeeDto> employeeDtos)
            {
                if (!string.IsNullOrEmpty(filter.Email))
                    employeeDtos = employeeDtos.Where(x => x.Data.EmailAddress.ToLower().Contains(filter.Email.ToLower()));
                if (!string.IsNullOrEmpty(filter.Role))
                    employeeDtos = employeeDtos.Where(x => x.Data.Role.Contains(filter.Role, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(filter.Specialty))
                    employeeDtos = employeeDtos.Where(x => x.Data.Specialty.ToLower().Contains(filter.Specialty.ToLower()));
                if (!string.IsNullOrEmpty(filter.Surname))
                    employeeDtos = employeeDtos.Where(x => x.Data.Surname.ToLower().Contains(filter.Surname.ToLower()));
                if (!string.IsNullOrEmpty(filter.WorkPlaceId))
                    employeeDtos = employeeDtos.Where(x => x.WorkPlace.ID.Contains(filter.WorkPlaceId));

                return employeeDtos;
            }
        }

        public class Filter
        {
            public string Email { get; set; }
            public string Role { get; set; }
            public string Specialty { get; set; }
            public string Surname { get; set; }
            public string WorkPlaceId { get; set; }
        }
    }
}
