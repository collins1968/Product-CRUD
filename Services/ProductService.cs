using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Asynchronous_programming.Models;

namespace Asynchronous_programming.Services
{
    public class ProductService : IProductsInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:3000/Products";

        public ProductService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<SuccessMessage> CreateProductAsync(AddProduct product)
        {
            var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, productJson);
            if(response.IsSuccessStatusCode)
            {
                return new  SuccessMessage {Message = "Product created successfully" };
            }
            throw new Exception("Product not created");   
        }

        public async Task<SuccessMessage> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            if(response.IsSuccessStatusCode)
            {
                return new SuccessMessage { Message = "Product deleted successfully" };
            }
            throw new Exception("Product not deleted");

        }

        public async Task<Product> GetProductAsync(int id)
        {
           var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            if(response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var product = await JsonSerializer.DeserializeAsync<Product>(responseStream);
                return product;
            }
            throw new Exception("Something went wrong");
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            if(response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var products = await JsonSerializer.DeserializeAsync<List<Product>>(responseStream);
                return products;
            }
            throw new Exception("Something went wrong");
        }

        public Task<SuccessMessage> UpdateProductAsync(Product product)
        {   
           var response = _httpClient.PutAsync($"{_baseUrl}/{product.id}", new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json"));
            if(response.IsCompletedSuccessfully)
            {
                return Task.FromResult(new SuccessMessage { Message = "Product updated successfully" });
            }
            throw new Exception("Product not updated");
        }
    }   
}
