using Asynchronous_programming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_programming.Services
{
    internal interface IProductsInterface
    {

        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<SuccessMessage> CreateProductAsync(AddProduct product);
        Task<SuccessMessage> UpdateProductAsync(Product product);
        Task<SuccessMessage> DeleteProductAsync(int id);
    }
}
