using APIPrueba1DD.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIPrueba1DD.Controllers.api
{
    public class ProductController : ApiController
    {
        private BProduct bProduct = new BProduct();

        public IEnumerable<Product> Get()
        {
            var response = new List<Product>();
            var products = bProduct.GetProductsActivate();
            response = products.Select(product => new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductInventory = product.ProductInventory,
                ProductExpiration = Product.reformatDate(product.ProductExpiration),
                ProductRegistered = Product.reformatDate(product.ProductRegistered)
            }).ToList();
            return response;
        }

        public IEnumerable<Product> GetDesactive()
        {
            var response = new List<Product>();
            var products = bProduct.GetProductsDesactive();
            response = products.Select(product => new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductInventory = product.ProductInventory,
                ProductExpiration = Product.reformatDate(product.ProductExpiration),
                ProductRegistered = Product.reformatDate(product.ProductRegistered)
            }).ToList();
            return response;
        }

        public void Post([FromBody] Product request)
        {
            bProduct.InsertProduct(new Entity.Product
            {
                ProductName = request.ProductName,
                ProductInventory = request.ProductInventory,
                ProductExpiration = DateTime.ParseExact(request.ProductExpiration, "MM/dd/yyyy", null),
                ProductRegistered = DateTime.ParseExact(request.ProductRegistered,"MM/dd/yyyy HH:mm:ss", null)
            });
        }

    }
}
