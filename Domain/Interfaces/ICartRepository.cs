using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(int id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task RemoveAsync(Cart cart);
    }
}
