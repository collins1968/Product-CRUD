using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous_programming.Models
{
    public class AddProduct
    {

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = "Product Description";

        public string Category { get; set; } = "Product Category";

        public string price { get; set; } = "Product Price";
    }
}
