using AutoMapper;
using Men_Fashion.Repo.Model;
using Men_Fashion.Repo.UnitOfWork;
using Men_Fashion.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Men_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("getCategory")]
        public IActionResult GetCategory()
        {
            var cate = _unitOfWork.category.GetAll();
            return Ok(cate);
        }
        [HttpPost("addCategory")]
        public IActionResult AddCategory([FromBody] CategoryRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                return BadRequest("Invalid category data.");
            }

            var category = _mapper.Map<Category>(categoryRequest);
            _unitOfWork.category.Add(category);
            _unitOfWork.save();

            return Ok(category);
        }
    }
}
