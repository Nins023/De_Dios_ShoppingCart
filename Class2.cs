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
                    Console.WriteLine($"{i + 1} - {Class1.shop[i]} - {Class1.price[i]} - {Class1.stock[i]}");
            }
        }

        public static void receipt()
        {
            foreach (string bought in Class1.purchases)
            {
                Console.WriteLine(bought);
                
            }
        }
    }
}
