using System;

namespace Task1
{
    public class Product : IEquatable<Product>
    {
       private string _name;

        public Product(string name, double price)
        {

            Name = name;
            Price = price;
        }

        
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value), "Cannot set to null");
        }

        public double Price { get; set; }


        public bool Equals(Product other)
        {
            return Name.Equals(other?.Name) && Price.Equals(other?.Price);
        }

    }
}
