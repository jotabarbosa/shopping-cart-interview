using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Entities
{
    public class Basket
    {
        public List<Item> Products { get; set; }
        public List<Discount> Discounts { get; set; }

        public Basket()
        {
            Products = new List<Item>();
            Discounts = new List<Discount>();
        }

        public void AddProduct(Item product, int quantity = 1)
        {
            if (Products.Where(x => x.Name == product.Name).Any())
            {
                foreach (var p in Products)
                {
                    if(p.Name == product.Name) p.Quantity += quantity;
                }
            }
            else 
            {
                if(quantity > 1)
                    product.Quantity = quantity;
                
                Products.Add(product);
            }
        }
        
        public void AddDiscount(Discount discount)
        {
            Discounts.Add(discount);
        }

        public void AddDiscounts(List<Discount> discounts)
        {
            Discounts = discounts;
        }

        public void Print()
        {
            Console.WriteLine();
            Products.ForEach(x => Console.WriteLine(x.Name + "\t x " + x.Quantity + "\t->\t" + Math.Round(x.Price, 2) + " euros"));
            
            Console.WriteLine();

            var sum = SumPrice();
            var discount = DiscountPrice();
            var total = sum - discount;

            Console.WriteLine("Sum " + sum + " euros");
            Console.WriteLine("Discount " + discount + " euros");
            Console.WriteLine("Total " + Math.Round(total, 2) + " euros");
            Console.WriteLine();
        }

        public double SumPrice()
        {
            double total = 0;

            Products.ForEach(p => total += (p.Price * p.Quantity));

            return Math.Round(total, 2);
        }

        public double DiscountPrice()
        {
            double total = 0;

            Discounts.ForEach(d => {
                var product = Products.FirstOrDefault(p => p.Name == d.Name);

                if (product != null)
                    total += (Math.Floor((double)(product.Quantity / d.Quantity)) * d.Price);
            });

            return Math.Round(total, 2);
        }
    }
}