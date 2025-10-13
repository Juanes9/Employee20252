using Employee.shared.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace Employee.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var action = await _unitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        //Este metodo me filtra por nombre o apellido
        [HttpGet("{filtro}")]
        public virtual async Task<IActionResult> GetAsync(string filtro)
        {
            var action = await _unitOfWork.GetAsync(filtro);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpGet("paginated")]
        public virtual async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalRecords")]
        public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalRecordsAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.DeleteAsync(id);
            if (action.WasSuccess)
            {
                return NoContent();
            }
            return BadRequest(action.Message);
        }
    }
}