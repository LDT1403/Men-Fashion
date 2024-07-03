using Men_Fashion.Repo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Men_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        [HttpGet]
        public IActionResult Get()
        {
            var product = _unitOfWork.product.GetAll();
            return Ok(product);
        }
    }
}
