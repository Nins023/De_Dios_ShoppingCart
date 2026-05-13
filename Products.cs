using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Product
    {

        private string name;
        private int price;
        private int stock;
        private string category;

        public string Name
        {
            get { return name; }
        }

        public int Price
        {
            get { return price; }
        }

        public int Stock
        {
            get { return stock; }
        }

        public string Category
        {
            get { return category; }
        }

        
        public Product(string name, int price, int stock, string category)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
            this.category = category;
        }

       
        public void SetStock(int stock)
        {
            if (stock >= 0)
            {
                this.stock = stock;
            }
        }

        public static Product[] Products = new Product[]
        {
                
                new Product ("Chocolate cake",  350,  30,  "Cake"),
                new Product ( "Strawberry cake", 300, 45,  "Cake"),
                new Product ( "Vanilla cake", 400,  20,  "Cake" ),
                new Product ( "Tea", 80,  50, "Drinks"),
                new Product ("Cola", 25,  60,  "Drinks"),
                new Product ("Chocolate chips muffin",  120,  40, "Dessert"),
                new Product ("Blueberry muffin", 130, 80, "Dessert"),
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
                    Console.WriteLine($"Product ID: {i + 1} | Product: {Products[i].Name} | Price: {Products[i].Price} | Stock: {Products[i].Stock} | Category: {Products[i].Category} | {lowstockwarn}");
                

            }
        }
    }

    }

