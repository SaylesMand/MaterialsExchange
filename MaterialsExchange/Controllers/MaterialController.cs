using MaterialsExchange.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialController(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        [HttpGet]
        public IActionResult GetMaterials()
        {
            var materials = _materialRepository.GetMaterials();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }
    }
}
