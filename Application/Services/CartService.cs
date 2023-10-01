using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDTO> GetCartByIdAsync(int userId)
        {
            var cart = await _cartRepository.GetByIdAsync(userId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            return new CartDTO
            {
                Id = cart.Id,
                Items = cart.Items.Select(ci => new CartItemDTO
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }

        public async Task AddProductToCartAsync(int cartId, CartItemDTO cartItemDTO)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            var cartItem = new CartItem
            {
                ProductId = cartItemDTO.ProductId,
                Quantity = cartItemDTO.Quantity
            };

            cart.Items.Add(cartItem);

            await _cartRepository.UpdateAsync(cart);
        }

        public async Task UpdateCartItemAsync(int cartId, int cartItemId, CartItemDTO cartItemDTO)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            var cartItem = cart.Items.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("CartItem not found");
            }

            cartItem.ProductId = cartItemDTO.ProductId;
            cartItem.Quantity = cartItemDTO.Quantity;

            await _cartRepository.UpdateAsync(cart);
        }

        public async Task RemoveCartItemAsync(int cartId, int cartItemId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            var cartItem = cart.Items.FirstOrDefault(ci => ci.Id == cartItemId);
            if (cartItem == null)
            {
                throw new NotFoundException("CartItem not found");
            }

            cart.Items.Remove(cartItem);

            await _cartRepository.UpdateAsync(cart);
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                throw new NotFoundException("Cart not found");
            }

            cart.Items.Clear();

            await _cartRepository.UpdateAsync(cart);
        }
    }
}