using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Product
    {

        public string Name;
        public int Price;
        public int Stock;


        public static Product[] Products = new Product[]
        {
                new Product {Name = "Chocolate Cake", Price = 350, Stock = 10},
                new Product {Name = "Strawberry Cake", Price = 300, Stock = 15},
                new Product {Name = "Vanilla Cake", Price = 400, Stock = 12 }

        };

        public static void DisplayProducts()
        { 
            
                for (int i = 0; i < Products.Length; i++)
                {
                    Console.WriteLine($"Product ID: {i + 1} | Product: {Products[i].Name} | Price: {Products[i].Price} | Stock: {Products[i].Stock}");
                }
            

        }
    }

    }

