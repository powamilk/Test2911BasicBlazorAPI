using BUS.Service.Interface;
using BUS.ViewModel.WorkHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/workhistory")]
    [ApiController]
    public class WorkHistoryController : ControllerBase
    {
        private readonly IWorkHistoryService _workHistoryService;

        public WorkHistoryController(IWorkHistoryService workHistoryService)
        {
            _workHistoryService = workHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkHistoryVM>>> GetAll()
        {
            var workHistories = await _workHistoryService.GetAllAsync();
            return Ok(workHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkHistoryVM>> GetById(int id)
        {
            var workHistory = await _workHistoryService.GetByIdAsync(id);
            if (workHistory == null)
            {
                return NotFound();
            }
            return Ok(workHistory);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] WorkHistoryCreateVM workHistoryCreateVM)
        {
            await _workHistoryService.AddAsync(workHistoryCreateVM);
            return CreatedAtAction(nameof(GetById), new { id = workHistoryCreateVM.HistoryId }, workHistoryCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] WorkHistoryUpdateVM workHistoryUpdateVM)
        {
            await _workHistoryService.UpdateAsync(id, workHistoryUpdateVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _workHistoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
