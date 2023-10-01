using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(int id, ProductDTO productDTO);
        Task RemoveProductAsync(int id);

    }
}
