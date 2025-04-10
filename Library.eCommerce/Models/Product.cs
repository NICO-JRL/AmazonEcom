using System;

namespace AmazonEcom.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string? Display => $"{Id}. {Name} - ${Price:F2} x {Quantity}";

        public Product()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }
    }
}
