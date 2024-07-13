using AutoMapper;
using Men_Fashion.Repo.Model;
using Men_Fashion.Repo.UnitOfWork;
using Men_Fashion.Request;
using Men_Fashion.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Men_Fashion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("addCart")]
        public IActionResult AddCart(AddCartRequest cartRequest)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "UserId");
            if(user == null)
            {
                return BadRequest("Invalid Token");
            }
            if (cartRequest.Quantity < 1)
            {
                return BadRequest("Số lượng phải lớn hơn 1");
            }

            var product = _unitOfWork.product.getID(cartRequest.ProductId);
            if (product == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }
            int userId = int.Parse(user.Value);
            var cart = _unitOfWork.cart.Find(c => c.UserId == userId && c.ProductId == cartRequest.ProductId).FirstOrDefault();
            if (cart != null)
            {
                cart.Quantity += cartRequest.Quantity;
                _unitOfWork.cart.Update(cart);
            }
            else
            {
                cart = new Cart
                {
                    UserId = userId,
                    ProductId = cartRequest.ProductId,
                    Quantity = cartRequest.Quantity,
                };
                _unitOfWork.cart.Add(cart);
            }

            _unitOfWork.save();

            return Ok(new BaseResponse
            {
                Message = "Add Success"
            }) ;
        }

        [HttpGet("getCart/{userId}")]
        public IActionResult GetCart(int userId)
        {
            var cartItems = _unitOfWork.cart.Find(c => c.UserId == userId)
                                             .Select(c => new {
                                                 Cart = c,
                                                 Product = _unitOfWork.product.getID(c.ProductId)
                                             })
                                             .ToList();

            var cartResponses = cartItems.Select(ci => new CartResponse
            {
                ProductId = ci.Cart.ProductId,
                Quantity = ci.Cart.Quantity,
                Price = ci.Product?.Price,
                ProductName = ci.Product?.ProductName,
                Thumbnail = ci.Product?.Thumbnail,
                Inventory = ci.Product?.Inventory
            }).ToList();

            return Ok(cartResponses);
        }

        [HttpDelete("deleteCart/{userId}/{productId}")]
        public IActionResult DeleteCart(int userId, int productId)
        {
            var cartItem = _unitOfWork.cart.Find(c => c.UserId == userId && c.ProductId == productId).FirstOrDefault();
            if (cartItem == null)
            {
                return NotFound("Cart item not found");
            }

            _unitOfWork.cart.Delete(cartItem.Id);
            _unitOfWork.save();

            return Ok("Product removed from cart successfully");
        }
    }
}
