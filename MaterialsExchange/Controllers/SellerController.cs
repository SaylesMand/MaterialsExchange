using AutoMapper;
using MaterialsExchange.Dto;
using MaterialsExchange.Interfaces;
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
        public SellerController(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
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
    }
}