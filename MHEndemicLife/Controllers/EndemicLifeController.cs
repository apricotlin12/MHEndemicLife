using MHEndemicLife.Core.Models;
using MHEndemicLife.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MHEndemicLife.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndemicLifeController : ControllerBase
    {
        private readonly EndemicLifeRepository _repository;

        public EndemicLifeController(EndemicLifeRepository repository)
        {
            _repository = repository;
        }

        // 取得全部資料
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EndemicLife>>> GetAll()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }

        // 取得單筆資料
        [HttpGet("{id}")]
        public async Task<ActionResult<EndemicLife>> GetById(int id)
        {
            var data = await _repository.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // 新增資料
        [HttpPost]
        public async Task<ActionResult<EndemicLife>> Add([FromBody] EndemicLife endemicLife)
        {
            if (endemicLife == null) return BadRequest();

            int newId = await _repository.Add(endemicLife);
            endemicLife.EndemicLife_Id = newId;

            return CreatedAtAction(nameof(GetById), new { id = newId }, endemicLife);
        }

        // 更新資料
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EndemicLife endemicLife)
        {
            if (endemicLife == null || id != endemicLife.EndemicLife_Id) return BadRequest();

            bool success = await _repository.Update(endemicLife);
            if (!success) return NotFound();

            return NoContent();
        }

        // 刪除資料
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _repository.Delete(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
