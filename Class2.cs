using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart_De_Dios
{
    internal class Class2
    {
        public static void menu()
        {
            
            for (int i = 0; i < Class1.shop.Length; i++)
            {
                  
                Console.WriteLine($"Item ID: {i + 1} | Pastries: {Class1.shop[i]} | Price: {Class1.price[i]} | Stock: {Class1.stock[i]}");
            }
        }

        public static void receipt()
        {
            
            Console.WriteLine("= = = = = Transactions = = = = =");
            foreach (string cake in Class1.receipt)
            {

                Console.WriteLine(cake);

                Console.WriteLine("= = = = = End of Transactions = = = = =");
            }
            
        }
    }
}
