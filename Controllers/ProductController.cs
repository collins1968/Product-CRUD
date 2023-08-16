using Asynchronous_programming.Models;
using Asynchronous_programming.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_programming.Controllers
{
    public class ProductController
    {
        ProductService _productService = new ProductService();

        public async Task shopMenu()
        {
            Console.WriteLine("Hello welcome to Collins Shop");
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Get all products");
            Console.WriteLine("2. Get a product by Id");
            Console.WriteLine("3. Create a product");
            Console.WriteLine("4. Update a product");
            Console.WriteLine("5. Delete a product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                   await GetAllProducts();
                    break;
                case 2:
                   await GetProductById();
                    break;
                case 3:
                   await CreateProduct();
                    break;
                case 4:
                    await UpdateProduct();
                    break;
                case 5:
                    DeleteProduct();
                    break;
                case 6:
                    Console.WriteLine("Thank you for visiting Collins Shop");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private async void DeleteProduct()
        {
          Console.WriteLine("Enter the Id of the product you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            var response = await _productService.DeleteProductAsync(id);
            Console.WriteLine(response.Message);
            await shopMenu();

        }

        private async Task UpdateProduct()
        {
            //GetAllProducts();
            Console.WriteLine("Enter the id of the product you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of the product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the product");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the category of the product");
            string category = Console.ReadLine();
            Console.WriteLine("Enter the price of the product");
            string price = Console.ReadLine();
            var product = new Product { id = id, Name = name, Description = description, Category = category, price = price };
            var response = await _productService.UpdateProductAsync(product);
            Console.WriteLine(response.Message);
            await shopMenu();
        }

        private async Task CreateProduct()
        {
            Console.WriteLine("Enter the name of the product");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the description of the product");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the category of the product");
            string category = Console.ReadLine();
            Console.WriteLine("Enter the price of the product");
            string price = Console.ReadLine();
            var product = new AddProduct { Name = name, Description = description, Category = category, price = price };

            var response = await _productService.CreateProductAsync(product);
            Console.WriteLine(response.Message);
            await shopMenu();

        }

        public async Task GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.id}, Name: {product.Name}, Description: {product.Description}, Category: {product.Category}, Price: {product.price}");
            }
            await shopMenu();
        }

        public async Task GetProductById()
        {
            Console.WriteLine("Enter the Id of the product you want to get");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = await _productService.GetProductAsync(id);
            Console.WriteLine($"Id: {product.id}, Name: {product.Name}, Description: {product.Description}, Category: {product.Category}, Price: {product.price}");
            await shopMenu();
        }
     

    }
}
