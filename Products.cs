using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Product
    {

        public string Name;
        public int Price;
        public int Stock;
        public string category;

        public static Product[] Products = new Product[]
        {
                
                new Product {Name = "Chocolate cake", Price = 350, Stock = 30, category = "Cake"},
                new Product {Name = "Strawberry cake", Price = 300, Stock = 45, category = "Cake"},
                new Product {Name = "Vanilla cake", Price = 400, Stock = 20, category = "Cake" },
                new Product {Name = "Tea", Price = 80, Stock = 50, category = "Drinks"},
                new Product {Name = "Cola", Price = 25, Stock = 60, category = "Drinks"},
                new Product {Name = "Chocolate chips muffin", Price = 120, Stock = 40, category = "Dessert"},
                new Product {Name = "Blueberry muffin", Price = 130, Stock = 80, category = "Dessert"},
        };

        public static void DisplayProducts()
        {

            for (int i = 0; i < Products.Length; i++)
            {
                string lowstockwarn = "";
                if (Products[i].Stock <= 5)
                {
                    lowstockwarn = "LOW STOCK!";
                }
                    Console.WriteLine($"Product ID: {i + 1} | Product: {Products[i].Name} | Price: {Products[i].Price} | Stock: {Products[i].Stock} | Category: {Products[i].category} | {lowstockwarn}");
                

            }
        }
    }

    }

