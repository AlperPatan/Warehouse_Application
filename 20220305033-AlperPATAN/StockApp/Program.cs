using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace StockApp
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            List<Product> products = ProductManager.LoadProducts();
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to the StockApp");
                Console.WriteLine("1.List");
                Console.WriteLine("2.Edit");
                Console.WriteLine("3.Add");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Search");
                Console.WriteLine("6.Quit");
                
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("------------- Listing Stocks -----------");
                        ProductManager.ListProducts();
                        Console.WriteLine(" ");
                        break;
                    case "2":
                        Console.WriteLine("------------- Edit Item -------------");
                        
                        while (true)
                        {
                            Console.Write("Enter Product ID to edit: ");
                            ProductManager.EditProduct();
                            break;
                        }
                        Console.WriteLine("");
                        break;


                    case "3":
                        Console.WriteLine("-------------Add Item-------------");
                        ProductManager.AddProduct();
                        Console.WriteLine(" ");

                        break;
                    case "4":
                        Console.WriteLine("------------- Delete Item -------------");

                        ProductManager.DeleteProduct();
                        Console.WriteLine(" ");
                        break;


                    case "5":
                        Console.WriteLine("------------ Search Item --------------");
                        ProductManager.SearchItem();
                        Console.WriteLine(" ");
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Exiting");

                        break;
                }

            }

        }
        
    }
}