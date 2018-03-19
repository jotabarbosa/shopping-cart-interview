using System;
using System.IO;
using System.Linq;
using ShoppingBasket.Entities;

namespace ShoppingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            shop.AddDiscount(new Discount("Papaya", 3, 0.50));
            shop.AddProduct(new Item("Apple", 0.25));
            shop.AddProduct(new Item("Orange", 0.30));
            shop.AddProduct(new Item("Banana", 0.15));
            shop.AddProduct(new Item("Papaya", 0.50));

            shop.Print();

            var basket = new Basket();
            basket.AddDiscounts(shop.Discounts);

            try 
            {
                basket = ReadDocument(shop, basket);
                PrintReceipt(basket);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: Missing GroceryList.txt file");
            }
        }

        private static void PrintReceipt(Basket basket)
        {
            basket.Print();
        }

        private static Basket ReadDocument(Shop shop, Basket basket)
        {
            string file = "GroceryList.txt";
            string[] lines = File.ReadAllLines(file);
            
            Console.WriteLine();
            Console.WriteLine("Contents of GroceryList.txt : ");
            foreach (string line in lines)
            {
                Console.WriteLine(line);

                var args = line.Split(' ');
                if(!args.Any()) 
                    break;

                var product = shop.GetProduct(args[0]);

                if (product != null)
                    if (args.Count() > 1 && int.TryParse(args[1], out int qty))
                        basket.AddProduct(product, qty);
                    else
                        basket.AddProduct(product);
                else
                    Console.WriteLine("INFO: Product " + args[0] + " not in stock! It will be ignored.");
            }

            return basket;
        }
    }
}