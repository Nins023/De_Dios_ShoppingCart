using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Class2
    {
        public static void receipt()
        {

            Console.WriteLine("= = = = = Transactions = = = = =");
            foreach (string cake in Class1.receipt)
            {

                Console.WriteLine(cake);

                Console.WriteLine("= = = = = End of Transactions = = = = =");
            }
        }

        public static void ords()
        {
            bool done = false;
            double discount = 0.90;


            while (!done)
            {

                Product.DisplayProducts();

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

                else if (order > Product.Products.Length)
                {
                    Console.WriteLine("Item ID does not exist!");
                }



                if (int.TryParse(add, out order) && order >= 1 && order <= Product.Products.Length)
                {

                    Console.Write("Enter purchase amount: ");
                    string amount = Console.ReadLine();
                    int amount_purchase;


                    if (int.TryParse(amount, out amount_purchase))
                    {
                        if (Class1.bamount + amount_purchase > 75)
                        {
                            Console.WriteLine("Cart is full! only 75 items only");
                            continue;
                        }


                        if (!enoughstock(order, amount_purchase))
                        {
                            notenoughstock();
                            continue;
                        }


                        Product.Products[order - 1].Stock -= amount_purchase;
                        Class1.Grand_Total1 += Product.Products[order - 1].Price * amount_purchase;
                        Class1.bamount += amount_purchase;


                        if (Class1.bought.ContainsKey(order))
                        {
                            Class1.bought[order] += amount_purchase;
                        }
                        else
                        {
                            Class1.bought[order] = amount_purchase;
                        }


                    }

                    Console.WriteLine($"You have purchased {amount_purchase} {Product.Products[order - 1].Name}");

                }
            }

           

        }


        public static bool enoughstock(int order, int quantity)
        {

            return Product.Products[order - 1].Stock >= quantity;
        }



        public static void notenoughstock()
        {
            Console.WriteLine("Insufficient stock!");
        }

        public static void getitemtotal(int Grand_Total1, Dictionary<int, int> bought, int bamount)
        {
            int Grand_Total = Grand_Total1;
            double discount = 0.90;
            bool paid = false;
            if (Grand_Total1 >= 5000)
            {
                Grand_Total = (int)(Grand_Total1 * discount);
            }
            Console.WriteLine($"Your total is: {Grand_Total}");
            while (!paid)
            {
                Console.Write("Proceed to payment? 1 - yes | 2 - no: ");
                string payment = Console.ReadLine();
                int payment2;

                if (!int.TryParse(payment, out payment2))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                switch (payment2) 
                {

                    case 1:

                        Console.Write("Enter payment: ");
                        string paycus = Console.ReadLine();
                        int paycus2;

                        if (!int.TryParse(paycus, out paycus2))
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }

                        if (paycus2 < Grand_Total)
                        {
                            Console.WriteLine("Invalid Payment");
                            continue;
                        }

                        int change = paycus2 - Grand_Total;
                        Console.WriteLine($"Change: {change}");
                        bought.Clear();
                        paid = true;


                        break;

                        case 2:

                        Console.WriteLine("Payment cancelled");
                        paid = true;

                        break;
                
                }

            }
        }

        public static void managecart()
        {
            

            bool back = false;
            while (!back)
            {

                Console.WriteLine("= = = = = CART MANAGEMENT = = = = =");
                Console.WriteLine("1 - View cart");
                Console.WriteLine("2 - Remove Item from cart");
                Console.WriteLine("3 - Update item quantity in cart");
                Console.WriteLine("4 - Clear cart");
                Console.WriteLine("5 - Checkout");
                Console.WriteLine("6 - Go back");
                string cartopt = Console.ReadLine();
                int cartopt2;



                if (!int.TryParse(cartopt, out cartopt2))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                switch (cartopt2)
                {
                    case 1:

                        Console.WriteLine("Cart");

                        foreach (var item in Class1.bought)
                        {
                            int itemID = item.Key;
                            int quantity = item.Value;

                            int itemPrice = Product.Products[itemID - 1].Price;
                            int total = itemPrice * quantity;

                            Class1.basket = $"{Product.Products[itemID - 1].Name} | Qty: {quantity} | Price: {itemPrice} | Total: {total}";
                            Console.WriteLine(Class1.basket);

                        }


                        break;

                    case 2:

                        Console.Write("Select ID to Remove: ");
                        string RemoveID = Console.ReadLine();
                        int RemoveID2;

                        if (!int.TryParse(RemoveID, out RemoveID2))
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }

                        if (Class1.bought.ContainsKey(RemoveID2))
                        {
                            int backstock = Class1.bought[RemoveID2];
                            Product.Products[RemoveID2 - 1].Stock += backstock;
                            
                            Class1.Grand_Total1 -= Product.Products[RemoveID2 - 1].Price * Class1.bought[RemoveID2];
                            Class1.bought.Remove(RemoveID2);
                            Console.WriteLine("Item Removed");

                        }

                        break;

                    case 3:

                        bool change = false;
                        while (!change)
                        {

                            Console.WriteLine("= = = = = Change Quantity = = = = =");
                            foreach (var item in Class1.bought)
                            {
                                int itemID = item.Key;
                                int quantity = item.Value;

                                int itemPrice = Product.Products[itemID - 1].Price;
                                int total = itemPrice * quantity;

                                Class1.basket = $"{Product.Products[itemID - 1].Name} | Qty: {quantity} | Price: {itemPrice} | Total: {total}";
                                Console.WriteLine(Class1.basket);

                            }
                            Console.WriteLine("Choose ID to change| N - End add/subtract quantities: ");
                            string chng = Console.ReadLine();
                            if (chng == "N" || chng == "n")
                            {
                                change = true;
                            }
                            int chng2;



                            if (!int.TryParse(chng, out chng2))
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }
                            if (Class1.bought.ContainsKey(chng2))
                            {
                                Console.WriteLine($"You have chosen {Product.Products[chng2 - 1].Name}");

                                Console.WriteLine("Would You like to add or reduce quantity of your chosen product? 1 - Add | 2 - Reduce: ");
                                string adr = Console.ReadLine();
                                int adr2;

                                if (!int.TryParse(adr, out adr2))
                                {
                                    Console.WriteLine("Invalid Input");
                                    continue;
                                }

                                if (adr2 == 1)
                                {
                                    Console.WriteLine("Input how many to add: ");
                                    string add = Console.ReadLine();
                                    int add2;
                                    if (!int.TryParse(add, out add2))
                                    {
                                        Console.WriteLine("Invalid Input");
                                        continue;
                                    }
                                    if (add2 > Product.Products[chng2 - 1].Stock)
                                    {
                                        Console.WriteLine($"Desired additional quantities is not possible | Current stock: {Product.Products[chng2 - 1].Stock}");
                                        continue;
                                    }

                                    if (add2 <= Product.Products[chng2 - 1].Stock)
                                    {
                                        if (add2 > 75)
                                        {
                                            Console.WriteLine("Desired additional quantities is more than cart can hold");
                                            continue;
                                        }
                                        Product.Products[chng2 - 1].Stock -= add2;
                                        int addquanti = Class1.bought[chng2] += add2;
                                        Class1.Grand_Total1 += Product.Products[chng2 - 1].Price * add2;



                                    }



                                }

                                if (adr2 == 2)
                                {
                                    Console.WriteLine("Input how many to Reduce: ");
                                    string sub = Console.ReadLine();
                                    int sub2;
                                    if (!int.TryParse(sub, out sub2))
                                    {
                                        Console.WriteLine("Invalid Input");
                                        continue;
                                    }

                                    if (sub2 > Class1.bought[chng2])
                                    {
                                        Console.WriteLine("Desired reduction is higher than in cart quantity");
                                        continue;
                                    }

                                   
                                        Product.Products[chng2 - 1].Stock += sub2;
                                        int addquanti = Class1.bought[chng2] -= sub2;
                                        Class1.Grand_Total1 -= Product.Products[chng2 - 1].Price * sub2;


                                }



                            }
                        }
                        break;
                    case 4:

                        Console.WriteLine("Cart will be cleared, continue? 1 - Yes 2 - No");
                        string clr =    Console.ReadLine();
                        int clr2;

                        if (!int.TryParse(clr, out clr2))
                        {
                            Console.WriteLine("Invalid Input");
                            continue;
                        }

                        if (clr2 == 1)
                        {
                            foreach (var prods in Class1.bought)
                            {
                                int ID = prods.Key;
                                int qunt = prods.Value;

                                Product.Products[ID - 1].Stock += qunt;
                            }

                            Class1.bought.Clear();
                            Class1.Grand_Total1 = 0;
                            Class1.bamount = 0;
                            Console.WriteLine("Cart Cleared");
                        }

                        else if (clr2 == 2)
                        {
                            Console.WriteLine("Cancelled");
                        }


                        break;

                    case 5:

                        Class2.getitemtotal(Class1.Grand_Total1, Class1.bought, Class1.bamount);

                        break;

            

                    case 6:

                        back = true;

                        break;


                }
            }
        }
    }
    }

    

