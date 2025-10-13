using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class EmployeesUnitOfWork : GenericUnitOfWork<EmployeeBD>, IEmployeesUnitOfWork
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesUnitOfWork(IGenericRepository<EmployeeBD> repository, IEmployeesRepository employeesRepository) : base(repository)
        {
            _employeesRepository = employeesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync() => await _employeesRepository.GetAsync();

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(string filter) => await _employeesRepository.GetAsync(filter);

        public override async Task<ActionResponse<IEnumerable<EmployeeBD>>> GetAsync(PaginationDTO pagination) => await _employeesRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _employeesRepository.GetTotalRecordsAsync(pagination);
    }
}