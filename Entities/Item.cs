using System;

namespace ShoppingBasket.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
            Quantity = 1;
        }

        public void Print(int position)
        {
            Console.WriteLine(position + ".\t" + Name + "\t->\t " + Math.Round(Price, 2) + " euros");
        }
    }
}