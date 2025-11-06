using Employee.Backend.Data;
using Employee.Backend.Helpers;
using Employee.Backend.Repositories.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Repositories.Implementations
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly DataContext _context;

        public StateRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
        {
            var state = await _context.States
                .AsNoTracking()
                .Include(s => s.City)
                .ToListAsync();
            return new ActionResponse<IEnumerable<State>>
            {
                WasSuccess = true,
                Result = state
            };
        }

        public override async Task<ActionResponse<State>> GetAsync(int id)
        {
            var state = await _context.States
                .AsNoTracking()
                .Include(s => s.City)
                .FirstOrDefaultAsync(s => s.Id == id);

            return new ActionResponse<State>
            {
                WasSuccess = true,
                Result = state
            };
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(string filter)
        {
            var state = await _context.States
                .AsNoTracking()
                .Include(c => c.City)
                .Where(c => c.Name.ToLower().Contains(filter))
                .ToListAsync();
            if (state == null)
            {
                return new ActionResponse<IEnumerable<State>>
                {
                    Message = "No se encontraron estados que coincidan con esos caracteres"
                };
            }
            return new ActionResponse<IEnumerable<State>>
            {
                WasSuccess = true,
                Result = state
            };
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.States.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<State>>
            {
                WasSuccess = true,
                Result = await queryable
                .AsNoTracking()
                    .Include(c => c.City)
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.States.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(c => c.Name.ToLower().Contains(pagination.Filter.ToLower()));
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