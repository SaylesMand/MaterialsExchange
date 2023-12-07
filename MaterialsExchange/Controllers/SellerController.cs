using AutoMapper;
using MaterialsExchange.Dto;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models;
using MaterialsExchange.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MaterialsExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : Controller
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        public SellerController(ISellerRepository sellerRepository, IMapper mapper, IMaterialRepository materialRepository)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
            _materialRepository = materialRepository;
        }
        [HttpGet]
        public IActionResult GetSellers()
        {
            var sellers = _mapper.Map<List<SellerDto>>(_sellerRepository.GetSellers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(sellers);
        }

        [HttpGet("{sellId}")]
        public IActionResult GetSeller(int sellId)
        {
            if (!_sellerRepository.SellerExists(sellId))
                return NotFound();

            var seller = _mapper.Map<SellerDto>(_sellerRepository.GetSeller(sellId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(seller);
        }

        [HttpPost]
        public IActionResult CreateSeller([FromBody] SellerDto sellerCreate)
        {
            if (sellerCreate == null)
                return BadRequest(ModelState);

            var seller = _sellerRepository.GetSellers()
                .Where(m => m.Name.Trim().ToUpper() == sellerCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (seller != null)
            {
                ModelState.AddModelError("", "Seller already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var SellerMap = _mapper.Map<Seller>(sellerCreate);

            if (!_sellerRepository.CreateSeller(SellerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");
        }
        [HttpPut("{sellerId}")]
        public IActionResult UpdateSeller(int sellerId, [FromBody] SellerDto updatedSeller)
        {
            if (updatedSeller == null)
                return BadRequest(ModelState);

            if (sellerId != updatedSeller.Id)
                return BadRequest(ModelState);

            if (!_sellerRepository.SellerExists(sellerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var sellerMap = _mapper.Map<Seller>(updatedSeller);

            if (!_sellerRepository.UpdateSeller(sellerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating seller");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{sellId}")]
        public IActionResult DeleteSeller(int sellId)
        {
            if (!_sellerRepository.SellerExists(sellId))
                return NotFound();

            var materialToDelete = _materialRepository.GetMaterialsOfASeller(sellId);
            var sellerToDelete = _sellerRepository.GetSeller(sellId);

            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_materialRepository.DeleteMaterials(materialToDelete.ToList()))
                ModelState.AddModelError("", "Something went wrond when deleting materials");


            if (!_sellerRepository.DeleteSeller(sellerToDelete))
                ModelState.AddModelError("", "Something went wrong deleting seller");

            return NoContent();
        }
    }
}