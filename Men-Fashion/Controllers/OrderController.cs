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
    public class OrderController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        

        }
        [HttpPost("add-Order")]
        public async Task<IActionResult> addOrder(OrderRequest orderRequest)
        {

            var user = User.Claims.FirstOrDefault(x => x.Type == "UserId");
            if (user == null)
            {
                return BadRequest("InValid");
            }
            int userID = int.Parse(user.Value);
          
            decimal totalMoney = 0;
            var order = new Order
            {
                UserId = userID,
                Name = orderRequest.Name,
                Phone = orderRequest.Phone,
                AddressDetail = orderRequest.AddressDetail,
                PaymentMethod = orderRequest.PaymentMethod,
                OrderDate = DateTime.UtcNow,
                Status = "1"

            };
            _unitOfWork.order.Add(order);
            _unitOfWork.save();
            List<ListOrder> item = new List<ListOrder>();
            foreach(var items in orderRequest.listOrders)
            {
                var quantity = items.Quantity;
                var productID = items.ProductID;
                var product = _unitOfWork.product.getID(productID);
                var orderDetail = new OrderDetail
                {
                    Quantity = quantity,
                    ProductId = productID,
                    Price = product.Price,
                    OrderId = order.Id
                    
                };
                
                totalMoney += (decimal)(quantity * product.Price);

              
                
                _unitOfWork.orderdetail.Add(orderDetail);
                var userIdFind = _unitOfWork.cart.GetAll(x =>x.UserId == userID && x.ProductId == productID).FirstOrDefault();
                if(userIdFind != null)
                {
                    _unitOfWork.cart.Delete(userIdFind.Id);
                }
              

                
            }
            order.TotalMoney = totalMoney;


            _unitOfWork.save();

            return Ok(new BaseResponse
            {
                Message = "Create Success"
            }) ;
        }
    }
}
