using AmazonEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        private ProductServiceProxy()
        {
            Products = new List<Product?>
            {
                new Product{Id = 1, Name ="Product 1"},
                new Product{Id = 2, Name ="Product 2"},
                new Product{Id = 3, Name ="Product 3"}
            };
            ShoppingCart = new List<Product?>();
        }

        private static ProductServiceProxy? instance;
        private static object instanceLock = new object();
        public static ProductServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                }
                return instance;
            }
        }

        public List<Product?> Products { get; private set; }
        public List<Product?> ShoppingCart { get; private set; }

        private int LastKey => Products.Any() ? Products.Select(p => p?.Id ?? 0).Max() : 0;

        public Product AddOrUpdate(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = LastKey + 1;
                Products.Add(product);
            }
            else
            {
                var existing = Products.FirstOrDefault(p => p?.Id == product.Id);
                if (existing != null)
                {
                    existing.Name = product.Name;
                    existing.Price = product.Price;
                    existing.Quantity = product.Quantity;
                }
            }
            return product;
        }

        public Product? Delete(int id)
        {
            
            if (id == 0)
            {
                return null;
            }
            Product? product = Products.FirstOrDefault(p => p?.Id == id);
            Products.Remove(product);
            return product;
        }

        public Product? GetById(int id) 
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public Product? AddToCart(int id, int quantity)
        {
            var product = Products.FirstOrDefault(p => p?.Id == id);
            if (product == null || product.Quantity < quantity) return null;

            var cartItem = ShoppingCart.FirstOrDefault(p => p?.Id == id);
            if (cartItem == null)
            {
                ShoppingCart.Add(new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            product.Quantity -= quantity;
            return product;
        }

        public Product? RemoveFromCart(int id)
        {
            var cartItem = ShoppingCart.FirstOrDefault(p => p?.Id == id);
            if (cartItem != null)
            {
                var inventoryItem = Products.FirstOrDefault(p => p?.Id == id);
                if (inventoryItem != null)
                {
                    inventoryItem.Quantity += cartItem.Quantity;
                }
                ShoppingCart.Remove(cartItem);
            }
            return cartItem;
        }

        public string Checkout()
        {
            decimal total = ShoppingCart.Sum(p => (p?.Price ?? 0) * (p?.Quantity ?? 0));
            decimal tax = total * 0.07m;
            decimal grandTotal = total + tax;

            var receipt = "----- RECEIPT -----\n";
            foreach (var item in ShoppingCart)
            {
                receipt += $"{item?.Name} - ${item?.Price:F2} x {item?.Quantity} = ${item?.Price * item?.Quantity:F2}\n";
            }
            receipt += $"-------------------\nSubtotal: ${total:F2}\nTax (7%): ${tax:F2}\nTotal: ${grandTotal:F2}\n";

            ShoppingCart.Clear();
            return receipt;
        }
    }
}