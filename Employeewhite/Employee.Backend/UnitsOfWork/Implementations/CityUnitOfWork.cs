using Employee.Backend.Repositories.Interfaces;
using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Employee.shared.Responses;

namespace Employee.Backend.UnitsOfWork.Implementations
{
    public class CityUnitOfWork : GenericUnitOfWork<City>, ICityUnitOfWork
    {
        private readonly ICityRepository _cityRepository;

        public CityUnitOfWork(IGenericRepository<City> repository, ICityRepository cityRepository) : base(repository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync() => await _cityRepository.GetAsync();

        public override async Task<ActionResponse<City>> GetAsync(int id) => await _cityRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(string filter) => await _cityRepository.GetAsync(filter);

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _cityRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _cityRepository.GetTotalRecordsAsync(pagination);
        public async Task<IEnumerable<City>> GetComboAsync(int stateId) => await _cityRepository.GetComboAsync(stateId);
    }
}
