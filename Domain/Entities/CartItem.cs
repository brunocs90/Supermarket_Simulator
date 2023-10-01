namespace Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation property for Product
        public Product? Product { get; set; }

        // Adicione a propriedade CartId
        public int CartId { get; set; } // Esta propriedade representa a relação com Cart
        public Cart? Cart { get; set; } // Adicione uma propriedade de navegação para o relacionamento
    }
}
