using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class StateUnitOfWork : GenericUnitOfWork<State>, IStateUnitOfWork
    {
        private readonly IStateRepository _stateRepository;

        public StateUnitOfWork(IGenericRepository<State> repository, IStateRepository stateRepository) : base(repository)
        {
            _stateRepository = stateRepository;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _stateRepository.GetAsync();

        public override async Task<ActionResponse<State>> GetAsync(int id) => await _stateRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(string filter) => await _stateRepository.GetAsync(filter);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _stateRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _stateRepository.GetTotalRecordsAsync(pagination);
    }
}
