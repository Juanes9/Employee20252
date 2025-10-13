using Employee.Backend.Data;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<EmployeeBD>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return new ActionResponse<IEnumerable<EmployeeBD>>
            {
                WasSuccess = true,
                Result = employees
            };
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(string filter)
        {
            filter = filter.ToLower();
            var employees = await _context.Employees
                .Where(e => e.FirstName.ToLower().Contains(filter) || e.LastName.ToLower().Contains(filter))
                .ToListAsync();

            if (employees == null)
            {
                return new ActionResponse<IEnumerable<EmployeeBD>>
                {
                    Message = "No se encontraron empleados que coincidan con esos caracteres"
                };
            }

            return new ActionResponse<IEnumerable<EmployeeBD>>
            {
                WasSuccess = true,
                Result = employees
            };
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.FirstName.ToLower().Contains(pagination.Filter) ||
                e.LastName.ToLower().Contains(pagination.Filter));
            }

            return new ActionResponse<IEnumerable<EmployeeBD>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.FirstName.ToLower().Contains(pagination.Filter.ToLower())
                || e.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}