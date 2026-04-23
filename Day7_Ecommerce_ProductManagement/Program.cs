using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Ecommerce_ProductManagement
{
    public class Product
    {
        private string name;
        private double price;
        private int quantity;

        // Property: Name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property: Price (Validation applied)
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative!");
                price = value;
            }
        }

        // Property: Quantity (Validation applied)
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative!");
                quantity = value;
            }
        }

        // Constructor
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Price: {Price}, Quantity: {Quantity}");
        }
    }

    // Product Collection with Indexer
    public class ProductCollection
    {
        private List<Product> products = new List<Product>();

        // Add product
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // Indexer
        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= products.Count)
                    throw new IndexOutOfRangeException("Invalid index!");
                return products[index];
            }
            set
            {
                if (index < 0 || index >= products.Count)
                    throw new IndexOutOfRangeException("Invalid index!");
                products[index] = value;
            }
        }

        public void DisplayAll()
        {
            foreach (var product in products)
            {
                product.Display();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductCollection inventory = new ProductCollection();

            // Adding products
            inventory.AddProduct(new Product("Laptop", 50000, 10));
            inventory.AddProduct(new Product("Mobile", 20000, 20));

            Console.WriteLine("Initial Products:");
            inventory.DisplayAll();

            // Access using indexer
            Console.WriteLine("\nAccess Product at index 0:");
            inventory[0].Display();

            // Modify using indexer
            inventory[1] = new Product("Tablet", 15000, 15);

            Console.WriteLine("\nAfter Modification:");
            inventory.DisplayAll();

            // Test validation (uncomment to check error)
            // inventory[0].Price = -100; 

            Console.ReadLine();

        }
    }
}
