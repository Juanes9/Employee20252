using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.UnitsOfWork.Interfaces
{
    public interface IStateUnitOfWork
    {
        Task<ActionResponse<IEnumerable<State>>> GetAsync();

        Task<ActionResponse<State>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<State>>> GetAsync(string filter);

        Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}
