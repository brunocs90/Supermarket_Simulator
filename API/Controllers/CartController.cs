using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDTO>> GetCartById(int userId)
        {
            try
            {
                var cart = await _cartService.GetCartByIdAsync(userId);
                return Ok(cart);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{cartId}/items")]
        public async Task<ActionResult> AddProductToCart(int cartId, [FromBody] CartItemDTO cartItemDTO)
        {
            try
            {
                await _cartService.AddProductToCartAsync(cartId, cartItemDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{cartId}/items/{cartItemId}")]
        public async Task<ActionResult> UpdateCartItem(int cartId, int cartItemId, [FromBody] CartItemDTO cartItemDTO)
        {
            try
            {
                await _cartService.UpdateCartItemAsync(cartId, cartItemId, cartItemDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{cartId}/items/{cartItemId}")]
        public async Task<ActionResult> RemoveCartItem(int cartId, int cartItemId)
        {
            try
            {
                await _cartService.RemoveCartItemAsync(cartId, cartItemId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{cartId}")]
        public async Task<ActionResult> ClearCart(int cartId)
        {
            try
            {
                await _cartService.ClearCartAsync(cartId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
