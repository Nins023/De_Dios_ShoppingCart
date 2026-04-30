using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;

namespace ShoppingCart_Prt2_De_Dios
{
    internal class Class1
    {
        
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

            
           
            
            double discount = 0.90;
          
            bool paid = false;
            bool exit = false;


            while (!exit)
            {
                Console.WriteLine("= = = = = De Dios shopping system = = = = =");
                Console.WriteLine("1 - See available items");
                Console.WriteLine("2 - Add to Cart");
                Console.WriteLine("3 - Search item");
                Console.WriteLine("4 - Category Filter");
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

                        Class2.search();


                        break;


                    case 4:
                        Class2.categoryfilter();

                        break;

                    case 5:

                        Class2.managecart();

                        break;

                    case 6:
                        exit = true;

                        break;
                    default:
                        Console.WriteLine("Choose between 1 - 6");
                        break;
                }


            }
        }

    }
}
