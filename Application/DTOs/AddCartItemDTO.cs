namespace Application.DTOs
{
    public class AddCartItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; } // Adicione a propriedade CartId aqui
    }
}
