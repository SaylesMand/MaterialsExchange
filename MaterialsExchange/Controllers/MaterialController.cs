using AutoMapper;
using MaterialsExchange.Dto;
using MaterialsExchange.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;
        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMaterials()
        {
            var materials = _mapper.Map<List<MaterialDto>>(_materialRepository.GetMaterials());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(materials);
        }

        [HttpGet("{mateId}")]
        public IActionResult GetMaterial(int mateId)
        {
            if (!_materialRepository.MaterialExists(mateId))
                return NotFound();

            var material = _mapper.Map<MaterialDto>(_materialRepository.GetMaterial(mateId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(material);
        }
    }
}
