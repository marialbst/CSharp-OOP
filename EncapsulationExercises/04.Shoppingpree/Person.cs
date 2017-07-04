using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Shoppingpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.products.AsReadOnly(); }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public string TryBuyProducts(Product product)
        {
            if(product.Cost <= this.money)
            {
                products.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
               return $"{this.Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            var products = this.products.Count > 0 ? string.Join(", ", this.products.Select(p => p.Name)) : "Nothing bought";
            return $"{this.Name} - {products}";
        }
    }
}
