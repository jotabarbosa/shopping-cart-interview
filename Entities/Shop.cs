using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Entities
{
    public class Shop
    {
        public List<Item> Products { get; set; }
        public List<Discount> Discounts { get; set; }

        public Shop()
        {
            Products = new List<Item>();
            Discounts = new List<Discount>();
        }

        public void AddProduct(Item product)
        {
            if(!Products.Where(p => p == product).Any())
                Products.Add(product);
        }

        public Item GetProduct(string productName)
        {
            return Products.FirstOrDefault(p => p.Name == productName);
        }

        public void AddDiscount(Discount discount)
        {
            if(!Discounts.Where(d => d == discount).Any())
                Discounts.Add(discount);
        }

        public Discount GetDiscount(string discountName)
        {
            return Discounts.FirstOrDefault(d => d.Name == discountName);
        }

        public void Print()
        {
            Console.WriteLine("««« Product List »»»");
            int index = 0;
            Products.ForEach(p => p.Print(index++));

            Console.WriteLine("««« Discount List »»»");
            Discounts.ForEach(d => d.Print());
        }
    }
}