using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;

namespace Shopping_Cart_De_Dios
{
    internal class Class1
    {
        public static string[] shop = ["Chocolate Cake", "Black Forest Cake", "Strawberry Cake", "Vanilla Cake", "Mocha Cake"];
        public static int[] price = [350, 550, 300, 250, 400];
        public static int[] stock = [80, 60, 45, 70, 45];
        public static List<string> purchases  = new List<string>();
        public static List<string> paycus = new List<string>();
        public static List<string> purchasenow = new List<string>();
        public static List<string> receipt = new List<string>();
        
        public static void Hello()
        {
           
        int[] cart = new int[shop.Length];

            
            int[] prices = new int[price.Length];
            
            int[] stocks = new int[stock.Length];
            string basket = string.Empty;
            List<int> CartItemNum = new List<int>();
            List<int> CartQuant = new List<int>();
            int Total_Price = 0;
            int remStock = 0;
            int Grand_Total = 0;
            int Grand_Total1 = 0;
            double discount = 0.90;
            int bamount = 0;
            Dictionary<int, int> bought = new Dictionary<int, int>();
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

                        Class2.menu();

                        break;

                    case 2:
                        bool done = false;
                        
                        while (!done) {

                            Class2.menu();

                            Console.Write("Enter number to add in cart (N to finish): ");
                            string add = Console.ReadLine();
                            int order;

                            if (add == "N" || add == "n")
                            {
                                done = true;
                                break;
                            }

                            

                            if (!int.TryParse(add, out order))
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }

                            else if (order > shop.Length) 
                            {
                                Console.WriteLine("Item ID does not exist!");
                            }



                            if (int.TryParse(add, out order) && order >= 1 && order <= shop.Length)
                            {
                                
                                    Console.Write("Enter purchase amount: ");
                                    string amount = Console.ReadLine();
                                    int amount_purchase;

                                if (int.TryParse(amount, out amount_purchase))
                                {
                                    if (bamount + amount_purchase > 75)
                                    {
                                        Console.WriteLine("Cart is full! only 75 items only");
                                        continue;
                                    }


                                    else if (stock[order - 1] < amount_purchase)
                                    {
                                        Console.WriteLine("Insufficient Stock");
                                        continue;
                                    }


                                    stock[order - 1] -= amount_purchase;
                                    Grand_Total1 += price[order - 1] * amount_purchase;
                                    bamount += amount_purchase;


                                    if (bought.ContainsKey(order))
                                    {
                                        bought[order] += amount_purchase;
                                    }
                                    else
                                    {
                                        bought[order] = amount_purchase;
                                    }
                                    

                                    }
                                    if (Grand_Total1 >= 5000)
                                    {
                                        Grand_Total = (int)(Grand_Total1 * discount);
                                    }

                                Console.WriteLine($"You have purchased {amount_purchase} {shop[order - 1]}");
                                }
                            }

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
                        paid = false;
                        Grand_Total = Grand_Total1;
                        if (Grand_Total1 >= 5000)
                        {
                            Grand_Total = (int)(Grand_Total1 * discount);
                        }
                        Console.WriteLine($"Your total is: $" + Grand_Total);
                        Console.Write("Would you like to continue to pay? 1 (yes) or 2 (no): ");
                        string option = Console.ReadLine();
                        int optpay;
                        if (int.TryParse(option, out optpay) && optpay == 1)
                        {



                            while (!paid)
                            {
                                

                                    Console.WriteLine($"Total amount: $" + Grand_Total);
                                    Console.Write("Enter amount of payment: ");
                                    string payment = Console.ReadLine();
                                    int userpay;

                                    if (int.TryParse(payment, out userpay) && userpay >= Grand_Total)
                                    {
                                        Console.WriteLine("Payment succsesfull");
                                        int change = userpay - Grand_Total;
                                        Console.WriteLine($"Change: " + change);
                                        paycus.Add($"Payment {payment} \nChange: {change}");
                                        Grand_Total = 0;
                                        Grand_Total1 = 0;
                                        bamount = 0;

                                        
                                    Console.WriteLine("= = = = = = RECEIPT  = = = = = = \n"); 
                                        foreach (var item in bought)
                                        {
                                        int itemID = item.Key;
                                        int quantity = item.Value;

                                        int itemPrice = price[itemID - 1];
                                        int total = itemPrice * quantity;
                                        
                                        string ords = $"{shop[itemID - 1]} | Qty: {quantity} | Price: {itemPrice} | Total: {total} | Payment: {userpay}| Change: {change}";
                                        Console.WriteLine(ords);
                                        receipt.Add(ords);
                                        }
                                        Console.WriteLine("\n= = = = = END OF RECEIPT = = = = =");

                                        bought.Clear();
                                        
                                        
                                        paid = true;
                                        break;
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
                        
                        Console.WriteLine("Cart");
                        
                        foreach (var item in bought)
                        {
                            int itemID = item.Key;
                            int quantity = item.Value;

                            int itemPrice = price[itemID - 1];
                            int total = itemPrice * quantity;

                            basket = $"{shop[itemID - 1]} | Qty: {quantity} | Price: {itemPrice} | Total: {total}";
                            Console.WriteLine(basket);
                            
                        }
                        
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
