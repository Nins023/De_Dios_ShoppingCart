using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Shopping_Cart_De_Dios
{
    internal class Class1
    {
        public static string[] shop = ["Soda", "Chips"];
        public static int[] price = [5000, 20];
        public static int[] stock = [50, 50];
        public static List<string> purchases  = new List<string>();
        public static void Hello()
        {
           
            int[] cart = new int[shop.Length];

            
            int[] prices = new int[price.Length];
            
            int[] stocks = new int[stock.Length];
            int Total_Price = 0;
            int remStock = 0;
            int Grand_Total = 0;
            int Grand_Total1 = 0;
            double discount = 0.90;

            bool exit = false;
            bool paid = false;

            while (!exit)
            {
                Console.WriteLine("= = = = = De Dios shopping system = = = = =");
                Console.WriteLine("1 - See available items");
                Console.WriteLine("2 - Add to Cart");
                Console.WriteLine("3 - See total");
                Console.WriteLine("4 - Payment");
                Console.WriteLine("5 - Cancel order");
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

                        for (int i = 0; i < shop.Length; i++)
                        {
                                Console.WriteLine($"{i + 1} - {shop[i]} - {price[i]} - {stock[i]}");
                        }

                        break;

                    case 2:
                        bool done = false;
                        while (!done) {
                            for (int i = 0; i < shop.Length; i++)
                            {

                                Console.WriteLine($"{i + 1} - Item: {shop[i]} | Price: {price[i]} | Stock: {stock[i]}");

                            }

                            Console.WriteLine("Enter number to add in cart (0 to finish): ");
                            string add = Console.ReadLine();
                            int order;

                            if (!int.TryParse(add, out order))
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }



                            if (order == 0)
                            {
                                done = true;
                                break;
                            }

                                if (int.TryParse(add, out order) && order >= 1 && order <= shop.Length)
                            {
                                
                                    Console.Write("Enter purchase amount: ");
                                    string amount = Console.ReadLine();
                                    int amount_purchase;
                                    
                                    if (int.TryParse(amount, out amount_purchase))
                                    {
                                        if (stock[order - 1] >= amount_purchase)
                                        {
                                            stock[order - 1] -= amount_purchase;
                                            Grand_Total1 += price[order - 1] * amount_purchase;
                                            purchases.Add($"You have purchased {amount} {shop[order - 1]} {price[order - 1]}");
                                    }
                                    else if (stock[order - 1] < amount_purchase)
                                    {
                                        Console.WriteLine("Insufficient Stock");
                                    }
                                    }
                                    if (Grand_Total1 >= 5000)
                                    {
                                        Grand_Total = (int)(Grand_Total1 * discount);
                                    }

                                
                                }
                            }

                        break;

                    case 3:

                        if (Grand_Total1 >= 5000)
                        {
                            Grand_Total = (int)(Grand_Total1 * discount);
                            Console.WriteLine($"Total amount $" + Grand_Total);
                        }



                        break;


                    case 4:
                        Console.WriteLine($"Your total is: $" + Grand_Total);
                        Console.Write("Would you like to continue to pay? 1 (yes) or 2 (no): ");
                        string option = Console.ReadLine();
                        int optpay;
                        if (int.TryParse(option, out optpay) && optpay == 1)
                        {



                            while (!paid)
                            {
                                if (Grand_Total1 >= 5000)
                                {
                                    Grand_Total = (int)(Grand_Total1 * discount);

                                    Console.WriteLine($"Total amount: $" + Grand_Total);
                                    Console.Write("Enter amount of payment: ");
                                    string payment = Console.ReadLine();
                                    int userpay;

                                    if (int.TryParse(payment, out userpay) && userpay >= Grand_Total)
                                    {
                                        Console.WriteLine("Payment succsesfull");
                                        int change = userpay - Grand_Total;
                                        Console.WriteLine($"Change: " + change);
                                        Grand_Total = 0;
                                        paid = true;

                                    }

                                    else if (!int.TryParse(payment, out userpay))
                                    {
                                        Console.WriteLine("Invalid Input");

                                    }

                                    else
                                    {
                                        Console.WriteLine("Payment is less than amount");

                                    }
                                }
                            }
                        }
                        else if (int.TryParse(option, out optpay) && optpay == 2)
                        {
                            continue;
                        }
                        else if (int.TryParse(option, out optpay) && optpay > 2)
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        else if (!int.TryParse(option, out optpay))
                        {
                            Console.WriteLine("Invalid Input");
                        }

                        break;

                   case 5:

                        exit = true;

                        break;
                }


            }
        }
        
    }
}
