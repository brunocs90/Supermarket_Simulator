using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemDTO>> GetCartItemsByCartIdAsync(int cartId);
        Task<CartItemDTO> GetCartItemByIdAsync(int cartItemId);
        Task AddCartItemAsync(AddCartItemDTO cartItemDTO);
        Task UpdateCartItemAsync(int cartItemId, CartItemDTO cartItemDTO);
        Task RemoveCartItemAsync(int cartItemId);
    }
}
