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
        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        [HttpGet]
        public IActionResult GetSellers()
        {
            var sellers = _sellerRepository.GetSellers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(sellers);
        }
    }
}