namespace ShoppingCart_Prt2_De_Dios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("De Dios Shopping cart system");
                    Console.WriteLine("Current stocks");
                    Product.DisplayProducts();
                    Console.WriteLine("Choose Option");
                    Console.WriteLine("1 - Shopping system");
                    Console.WriteLine("2 - Receipts/Purchase history");
                    Console.WriteLine("3 - End Program");
                    Console.Write("Enter Option: ");
                    string Options = Console.ReadLine();
                    int choice;
                    if (int.TryParse(Options, out choice))
                    {
                        switch (choice)
                        {
                            case 1:

                                Class1.Hello();

                                break;

                            case 2:

                                Class2.receipt();

                                break;


                            case 3:

                                exit = true;

                                break;
                            default:

                                Console.WriteLine("Invalid Option");

                                break;
                        }
                    }
                }
            }

        }
    }

