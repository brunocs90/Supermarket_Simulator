namespace Application.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
    }
}
