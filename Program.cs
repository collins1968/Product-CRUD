using Asynchronous_programming.Controllers;

ProductController productController = new ProductController();

productController.shopMenu().Wait();
