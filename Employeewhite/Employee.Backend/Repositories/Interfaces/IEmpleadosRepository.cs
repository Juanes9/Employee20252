using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.Repositories.Interfaces
{
    public interface IEmpleadosUnitOfWork
    {
        Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync();

        Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(string filtro);

        Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}