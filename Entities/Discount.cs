using System;

namespace ShoppingBasket.Entities
{
    public class Discount
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Discount(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine(Name + "\t x " + Quantity + "\t->\t " + "-" + Math.Round(Price, 2) + " euros");
            Console.WriteLine();
        }
    }
}