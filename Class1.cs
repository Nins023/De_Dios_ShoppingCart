using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Class1
    {
        public static string[] shop = ["Chocolate Cake", "Black Forest Cake", "Strawberry Cake", "Vanilla Cake", "Mocha Cake"];
        public static int[] price = [350, 550, 300, 250, 400];
        public static int[] stock = [80, 60, 45, 70, 45];
        public static List<string> purchases = new List<string>();
        public static List<string> paycus = new List<string>();
        public static List<string> purchasenow = new List<string>();
        public static List<string> receipt = new List<string>();
        public static Dictionary<int, int> bought = new Dictionary<int, int>();
        public static int Grand_Total1 = 0;
        public static int bamount = 0;
        public static int Grand_Total = 0;
        public static string basket = string.Empty;

        public static void Hello()
        {

            int[] cart = new int[shop.Length];


            int[] prices = new int[price.Length];

            int[] stocks = new int[stock.Length];
            
            List<int> CartItemNum = new List<int>();
            List<int> CartQuant = new List<int>();
            int Total_Price = 0;
            int remStock = 0;
           
            
            double discount = 0.90;
          
            bool paid = false;
            bool exit = false;


            while (!exit)
            {
                Console.WriteLine("= = = = = De Dios shopping system = = = = =");
                Console.WriteLine("1 - See available items");
                Console.WriteLine("2 - Add to Cart");
                Console.WriteLine("3 - See total");
                Console.WriteLine("4 - Payment");
                Console.WriteLine("5 - See Cart");
                Console.WriteLine("6 - Exit");
                Console.Write("Enter Option: ");
                string user = Console.ReadLine();
                int choice;

                if (!int.TryParse(user, out choice))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                switch (choice)
                {
                    case 1:

                        Product.DisplayProducts();

                        break;

                    case 2:
                        Class2.ords();

                        break;

                    case 3:

                        Grand_Total = Grand_Total1;

                        if (Grand_Total1 >= 5000)
                        {
                            Grand_Total = (int)(Grand_Total1 * discount);
                            Console.WriteLine($"Total amount $" + Grand_Total);
                        }
                        else if (Grand_Total < 5000)
                        {
                            Console.WriteLine($"Total amount: {Grand_Total}");
                        }



                        break;


                    case 4:
                        Class2.getitemtotal(Class1.Grand_Total1, Class1.bought, Class1.bamount);

                        break;

                    case 5:

                        Class2.managecart();

                        break;

                    case 6:
                        Console.WriteLine("You are exiting the system if not yet paid progress will be lost");
                        Console.WriteLine("1 (continue) \n2 (go back)");
                        string des = Console.ReadLine();
                        int decide;
                        if (!int.TryParse(des, out decide))
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        else if (decide == 1)
                        {

                            exit = true;
                            if (!paid)
                            {
                                purchasenow.Clear();
                                bamount = 0;
                            }
                        }
                        else if (decide == 2)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                        }

                        break;

                    default:

                        Console.WriteLine("Please enter an option between 1-6");

                        break;
                }


            }
        }

    }
}
