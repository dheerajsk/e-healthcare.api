using EHealthcare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Cart")]
    public class CartController : BaseController<Cart>
    {
        private readonly IBaseRepository<CartItem> CartItemRepository;
        public CartController(IBaseRepository<CartItem> _CartRepository)
        {
            CartItemRepository = _CartRepository;
        }

        [HttpGet("GetByUserID")]
        public IActionResult Get()
        {
            Cart result = Repository.Get().Where(i => i.OwnerID == SessionUser.ID).FirstOrDefault();
            if (result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [Route("PlaceOrder")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var userCart = Repository.Get().Where(i => i.OwnerID == SessionUser.ID).FirstOrDefault();

            if (userCart is null)
            {
                userCart = await Repository.Add(new Cart { OwnerID = SessionUser.ID });
            }
            foreach (var item in userCart.Items)
            {
                CartItemRepository.Delete(item.ID);
            }
            return Ok();
        }

        [Route("Add/{productID}")]
        [HttpPost]
        public async Task<IActionResult> Post(long productID)
        {
            var userCart = Repository.Get().Where(i => i.OwnerID == SessionUser.ID).FirstOrDefault();

            if (userCart is null)
            {
                userCart = await Repository.Add(new Cart { OwnerID = SessionUser.ID });
            }
            var cartItem = new CartItem { CartID = userCart.ID, ProductID = productID };
            var result = CartItemRepository.Add(cartItem);
            return Ok();
        }

        public async override Task<IActionResult> Delete(long id)
        {
            await CartItemRepository.Delete(id);
            return Ok(); ;
        }
    }
}
