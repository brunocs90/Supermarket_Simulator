using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICartService
    {
        Task<CartDTO> GetCartByIdAsync(int userId);
        Task AddProductToCartAsync(int cartId, CartItemDTO cartItemDTO);
        Task UpdateCartItemAsync(int cartId, int cartItemId, CartItemDTO cartItemDTO);
        Task RemoveCartItemAsync(int cartId, int cartItemId);
        Task ClearCartAsync(int cartId);
    }
}
