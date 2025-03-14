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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EndemicLife>>> GetAll()
        {
            var data = await _repository.GetAll();
            return Ok(data);
        }
    }
}
