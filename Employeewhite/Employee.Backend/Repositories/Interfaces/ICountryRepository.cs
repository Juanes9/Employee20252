using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<ActionResponse<IEnumerable<Country>>> GetAsync();

        Task<ActionResponse<IEnumerable<Country>>> GetAsync(string filter);

        Task<ActionResponse<Country>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}
