using System;

namespace AmazonEcom.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
     
        public string? Display
        {
            get
            {
                return $"{Id}. {Name}";
            }
        }

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
