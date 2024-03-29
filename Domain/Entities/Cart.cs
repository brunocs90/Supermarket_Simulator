﻿namespace Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
