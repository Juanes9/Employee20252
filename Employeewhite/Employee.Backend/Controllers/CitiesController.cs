using Employee.Backend.UnitsOfWork.Interfaces;
using Employee.shared.DTOs;
using Employee.shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : GenericController<City>
    {
        private readonly ICityUnitOfWork _cityUnitOfWork;

        public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICityUnitOfWork cityUnitOfWork) : base(unitOfWork)
        {
            _cityUnitOfWork = cityUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _cityUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _cityUnitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("{filter}")]
        public override async Task<IActionResult> GetAsync(string filter)
        {
            var action = await _cityUnitOfWork.GetAsync(filter);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _cityUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _cityUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
