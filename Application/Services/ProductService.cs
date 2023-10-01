using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            var product = new Product(productDTO.Name, productDTO.Price);
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductDTO productDTO)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            product.Name = productDTO.Name;
            product.Price = productDTO.Price;

            await _productRepository.UpdateAsync(product);
        }

        public async Task RemoveProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            await _productRepository.RemoveAsync(product);
        }
    }
}
