using System;
using System.Linq;

namespace ECommercePlatformSearch
{
    // Product class with attributes: productId, productName, and category
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        // Constructor for Product
        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        // Method to display product details
        public override string ToString()
        {
            return $"{ProductName} (ID: {ProductId}, Category: {Category})";
        }
    }

    class Program
    {
        // Linear Search Algorithm
        public static Product LinearSearch(Product[] products, string searchTerm)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return product;  // Return the first matching product
                }
            }
            return null; // No product found
        }

        // Binary Search Algorithm (requires sorted data)
        public static Product BinarySearch(Product[] products, string searchTerm)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                var comparison = string.Compare(products[mid].ProductName, searchTerm, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    return products[mid];  // Found the product
                }

                if (comparison < 0)
                {
                    left = mid + 1;  // Search in the right half
                }
                else
                {
                    right = mid - 1;  // Search in the left half
                }
            }

            return null; // No product found
        }

        // Helper method to print the search result
        public static void PrintSearchResult(Product product)
        {
            if (product != null)
            {
                Console.WriteLine($"Product found: {product}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void Main(string[] args)
        {
            // Setting up a list of products for the e-commerce platform
            Product[] products = new Product[]
            {
                new Product(1, "Apple iPhone 13", "Electronics"),
                new Product(2, "Samsung Galaxy S21", "Electronics"),
                new Product(3, "Dell XPS 13", "Computers"),
                new Product(4, "Nike Air Max", "Footwear"),
                new Product(5, "Sony WH-1000XM4", "Headphones")
            };

            // Linear Search Test
            Console.WriteLine("---- Linear Search ----");
            string linearSearchTerm = "Nike Air Max";  // Searching for a product by name
            Console.WriteLine($"Searching for: {linearSearchTerm}");
            Product linearSearchResult = LinearSearch(products, linearSearchTerm);
            PrintSearchResult(linearSearchResult);

            // Binary Search Test (Requires Sorted Data)
            // Sorting products by ProductName to apply Binary Search
            var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();

            Console.WriteLine("\n---- Binary Search ----");
            string binarySearchTerm = "Sony WH-1000XM4";  // Searching for a product by name
            Console.WriteLine($"Searching for: {binarySearchTerm}");
            Product binarySearchResult = BinarySearch(sortedProducts, binarySearchTerm);
            PrintSearchResult(binarySearchResult);

            // Additional search to show performance difference
            string noMatchSearchTerm = "MacBook Pro";
            Console.WriteLine("\nSearching for a non-existent product:");
            Product noMatchResult = BinarySearch(sortedProducts, noMatchSearchTerm);
            PrintSearchResult(noMatchResult);
        }
    }
}