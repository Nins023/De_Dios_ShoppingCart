using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart_De_Dios
{
    internal class Class1
    {
        public static void Hello()
        {
            string[] shop = ["Soda", "Chips"];
            int[] cart = new int[shop.Length];
            int[] price = [10, 20];
            int[] prices = new int[price.Length];
            int Total_Price = 0;

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("= = = = = De Dios shopping system = = = = =");
                Console.WriteLine("1 - See available items");
                Console.WriteLine("2 - Add to Cart");
                Console.WriteLine("3 - See total");
                Console.WriteLine("4 - Payment");
                Console.WriteLine("5 - Exit");
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

                        for (int i = 0; i < shop.Length; i++)
                        {
                            for (int x = 0; x < price.Length; x++)
                                Console.WriteLine($"{i + 1} - {shop[i]} - {price[i]}");
                        }

                        break;

                    case 2:

                        for (int i = 0; i < shop.Length; i++)
                        {
                            for (int x = 0; x < price.Length; x++)
                                Console.WriteLine($"{i + 1} - {shop[i]} - {price[i]}");
                        }

                        Console.WriteLine("Enter number to add in cart: ");
                        string add = Console.ReadLine();
                        int order;

                        if (int.TryParse(add, out order) && order >= 1 && order <= shop.Length)
                        {
                            Total_Price += price[order - 1];
                        }

                        if (!int.TryParse(add, out order))
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        break;

                    case 3:

                        Console.WriteLine($"Total amount $" + Total_Price);

                        break;
                }


            }
        }
    }
}
