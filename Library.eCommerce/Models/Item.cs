using AmazonEcom.Models;
using Library.eCommerce.DTO;
using System;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }

        public ProductDTO Product { get; set; }

        public int? Quantity { get; set; }

        public double TotalPrice
        {
            get => (Product?.Price ?? 0) * (Quantity ?? 0);
        }

        public string Display
        {
            get => $"{Product?.Display ?? string.Empty} Qty: {Quantity}, Price: ${TotalPrice:F2}";
        }

        public override string ToString()
        {
            return Display;
        }

        public Item()
        {
            Product = new ProductDTO();
            Quantity = 0;
        }

        public Item(Item i)
        {
            Product = new ProductDTO(i.Product);
            Quantity = i.Quantity;
            Id = i.Id;
        }
    }
}
