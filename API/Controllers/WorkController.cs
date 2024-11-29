using BUS.Service.Interface;
using BUS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/works")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkService _service;

        public WorkController(IWorkService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkVM>>> GetAll()
        {
            var work = await _service.GetAllAsync();
            return Ok(work);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkVM>> GetById(int id)
        {
            var work = await _service.GetByIdAsync(id);
            if (work == null)
            {
                return NotFound();
            }    
            return Ok(work);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] WorkCreateVM work)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            await _service.CreateAsync(work);
            return CreatedAtAction(nameof(GetById), new { id = work.WorkId }, work);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] WorkUpdateVM work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != work.WorkId)
            {
                return BadRequest(new { Message = "id khong khop" });
            }
            var exiting = await _service.GetByIdAsync(id);
            if(exiting == null)
            {
                return NotFound();
            }    
            await _service.UpdateAsync(work);   
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id )
        {
            var exiting = await _service.GetByIdAsync(id);
            if (exiting == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
