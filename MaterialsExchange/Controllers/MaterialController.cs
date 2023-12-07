using AutoMapper;
using MaterialsExchange.Dto;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models;
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
        [HttpPost]
        public IActionResult CreateMaterial([FromBody] MaterialDto materialCreate)
        {
            if (materialCreate == null)
                return BadRequest(ModelState);

            var material = _materialRepository.GetMaterials()
                .Where(m => m.Name.Trim().ToUpper() == materialCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (material != null)
            {
                ModelState.AddModelError("", "Material already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var MaterialMap = _mapper.Map<Material>(materialCreate);

            if (!_materialRepository.CreateMaterial(MaterialMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }
        [HttpPut("{materialId}")]
        public IActionResult UpdateMaterial(int materialId, [FromBody] MaterialDto updatedMaterial)
        {
            if (updatedMaterial == null)
                return BadRequest(ModelState);

            if (materialId != updatedMaterial.Id)
                return BadRequest(ModelState);

            if (!_materialRepository.MaterialExists(materialId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var materialMap = _mapper.Map<Material>(updatedMaterial);

            if (!_materialRepository.UpdateMaterial(materialMap))
            {
                ModelState.AddModelError("", "Something went wrong updating material");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }
    }
}
