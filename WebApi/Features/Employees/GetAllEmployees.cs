using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                var employees = await _context.Users.ToListAsync();
                var employeeDtos = employees.Select(_mapper.Map<EmployeeDto>).ToList();

                for (int i = 0; i < employeeDtos.Count(); i++)
                {
                    employeeDtos[i].Role = (await _userManager.GetRolesAsync(employees[i])).Single();
                }
                employeeDtos = ApplyFiltering(request.Filter, employeeDtos).OrderBy(x => x.Surname).ThenBy(x => x.Name).ThenBy(x => x.Specialty).ToList();

                return PagingLogic.GetPagedContent(employeeDtos, request.PagingReferences);
            }

            private IEnumerable<EmployeeDto> ApplyFiltering(Filter filter, IEnumerable<EmployeeDto> employeeDtos)
            {
                if (!string.IsNullOrEmpty(filter.Email))
                    employeeDtos = employeeDtos.Where(x => x.EmailAddress.Contains(filter.Email));
                if (!string.IsNullOrEmpty(filter.Role))
                    employeeDtos = employeeDtos.Where(x => x.Role.Contains(filter.Role, StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(filter.Specialty))
                    employeeDtos = employeeDtos.Where(x => x.Specialty.Contains(filter.Specialty));
                if (!string.IsNullOrEmpty(filter.Surname))
                    employeeDtos = employeeDtos.Where(x => x.Surname.Contains(filter.Surname));

                return employeeDtos;
            }
        }

        public class Filter
        {
            public string Email { get; set; }
            public string Role { get; set; }
            public string Specialty { get; set; }
            public string Surname { get; set; }
        }
    }
}
