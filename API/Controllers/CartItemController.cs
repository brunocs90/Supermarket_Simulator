using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/cartitems")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("cart/{cartId}")] // Ajuste a rota para incluir "cart/"
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetCartItemsByCartId(int cartId)
        {
            try
            {
                var cartItems = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
                return Ok(cartItems);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{cartItemId}")] // Ajuste a rota para "{cartItemId}"
        public async Task<ActionResult<CartItemDTO>> GetCartItemById(int cartItemId)
        {
            try
            {
                var cartItem = await _cartItemService.GetCartItemByIdAsync(cartItemId);
                return Ok(cartItem);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCartItem([FromBody] AddCartItemDTO addCartItemDTO) // Use AddCartItemDTO aqui
        {
            try
            {
                await _cartItemService.AddCartItemAsync(addCartItemDTO); // Use AddCartItemAsync
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{cartItemId}")]
        public async Task<ActionResult> UpdateCartItem(int cartItemId, [FromBody] CartItemDTO cartItemDTO)
        {
            try
            {
                await _cartItemService.UpdateCartItemAsync(cartItemId, cartItemDTO);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{cartItemId}")]
        public async Task<ActionResult> RemoveCartItem(int cartItemId)
        {
            try
            {
                await _cartItemService.RemoveCartItemAsync(cartItemId);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}