using AutoMapper;
using Men_Fashion.Repo.Model;
using Men_Fashion.Repo.UnitOfWork;
using Men_Fashion.Request;
using Men_Fashion.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Men_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("getProduct")]
        public IActionResult GetProduct()
        {
            var products = _unitOfWork.product.GetAll();
            var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Ok(productResponses);
        }
        [HttpGet("GetProductTrend")]
        public IActionResult GetProductTrend()
        {
            var product = _unitOfWork.product.GetAll().Take(6).OrderByDescending(x => x.Id);
            var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(product);
            return Ok(productResponses);
        }

        [HttpGet("GetProductSeller")]
        public IActionResult GetProductSeller()
        {
            var product = _unitOfWork.product.GetAll().Take(6).OrderByDescending(x => x.Inventory);
            var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(product);
            return Ok(productResponses);
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct([FromBody] ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest("Invalid product data.");
            }

            try
            {
                var product = _mapper.Map<Product>(productRequest);

                _unitOfWork.product.Add(product);
                _unitOfWork.save();

                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _unitOfWork.product.getID(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            var productResponse = _mapper.Map<ProductResponse>(product);

            return Ok(productResponse);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.product.getID(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }
            product.IsDeleted = "1";
            _unitOfWork.product.Update(product);
            _unitOfWork.save();

            return Ok("Delete Success");
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductRequest productRequest)
        {
            try
            {
                var existingProduct = _unitOfWork.product.getID(id);

                if (existingProduct == null)
                {
                    return NotFound("Product not found");
                }
                _mapper.Map(productRequest, existingProduct);

                _unitOfWork.product.Update(existingProduct);
                _unitOfWork.save();

                return Ok(existingProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("searchProduct")]
        public IActionResult SearchProduct([FromBody] SearchProductRequest searchRequest)
        {
            if (string.IsNullOrEmpty(searchRequest.Keyword))
            {
                return BadRequest("Keyword cannot be empty.");
            }

            var products = _unitOfWork.product.GetAll()
                .Where(p =>
                    p.ProductName.Contains(searchRequest.Keyword) ||
                    p.Description.Contains(searchRequest.Keyword)
                );

            var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Ok(productResponses);
        }
    }
}
