using Employee.Backend.Data;
using Employee.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeesController : GenericController<EmployeeBD>
    {
        private readonly IEmployeesUnitOfWork _employeesUnitOfWork;

        public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork, IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
        {
            _employeesUnitOfWork = employeesUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _employeesUnitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        //Este metodo me filtra por nombre o apellido
        [HttpGet("{filtro}")]
        public override async Task<IActionResult> GetAsync(string filtro)
        {
            var action = await _employeesUnitOfWork.GetAsync(filtro);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _employeesUnitOfWork.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _employeesUnitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}