using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItemDTO>> GetCartItemsByCartIdAsync(int cartId)
        {
            var cartItems = await _cartItemRepository.GetByCartIdAsync(cartId);
            return cartItems.Select(ci => new CartItemDTO
            {
                Id = ci.Id,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity
            });
        }

        public async Task<CartItemDTO> GetCartItemByIdAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("CartItem not found");
            }

            return new CartItemDTO
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity
            };
        }

        public async Task AddCartItemAsync(AddCartItemDTO cartItemDTO)
        {
            var cartItem = new CartItem
            {
                ProductId = cartItemDTO.ProductId,
                Quantity = cartItemDTO.Quantity,
                CartId = cartItemDTO.CartId // Defina a propriedade CartId aqui
            };

            await _cartItemRepository.AddAsync(cartItem);
        }

        public async Task UpdateCartItemAsync(int cartItemId, CartItemDTO cartItemDTO)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("CartItem not found");
            }

            // Atualize as propriedades do item de carrinho com os valores fornecidos em cartItemDTO
            cartItem.ProductId = cartItemDTO.ProductId;
            cartItem.Quantity = cartItemDTO.Quantity;

            await _cartItemRepository.UpdateAsync(cartItem);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("CartItem not found");
            }

            await _cartItemRepository.RemoveAsync(cartItem);
        }
    }
}