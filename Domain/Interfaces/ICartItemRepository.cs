using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem?> GetByIdAsync(int id);
        Task<IEnumerable<CartItem>> GetByCartIdAsync(int cartId);
        Task AddAsync(CartItem cartItem);
        Task UpdateAsync(CartItem cartItem);
        Task RemoveAsync(CartItem cartItem);
    }
}
