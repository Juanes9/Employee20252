using Employee.Backend.Data;
using Employee.shared.DTOs;
using Employee.shared.Responses;

namespace Employee.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<EmployeeBD>, IEmployeesRepository
    {
        private readonly DataContext _context;

        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync()
        {
            var empleados = await _context.Empleados.ToListAsync();
            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = empleados
            };
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(string filtro)
        {
            filtro = filtro.ToLower();
            var empleados = await _context.Empleados
                .Where(e => e.FirstName.ToLower().Contains(filtro) || e.LastName.ToLower().Contains(filtro))
                .ToListAsync();

            if (empleados == null)
            {
                return new ActionResponse<IEnumerable<Empleado>>
                {
                    Message = "No se encontraron empleados que coincidan con esos caracteres"
                };
            }

            return new ActionResponse<IEnumerable<Empleado>>
            {
                WasSuccess = true,
                Result = empleados
            };
        }

        public override async Task<ActionResponse<IEnumerable<Empleado>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(e => e.FirstName.ToLower().Contains(pagination.Filter) ||
                e.LastName.ToLower().Contains(pagination.Filter));
            }

            return new ActionResponse<IEnumerable<Empleado>>
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
            var queryable = _context.Empleados.AsQueryable();

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