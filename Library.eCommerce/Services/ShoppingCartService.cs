﻿using AmazonEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.eCommerce.Services
{
    public class ShoppingCartService
    {
        private List<Product> items;
        public List<Product> CartItems
        {
            get
            { 
                return items;
            }
        }
        public static ShoppingCartService Current {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingCartService();
                }

                return instance;
            }
        }
        private static ShoppingCartService? instance;
        private ShoppingCartService() { 
            items = new List<Product>();
        }
    }
}
