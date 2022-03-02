using APIPrueba1DD.Models;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace APIPrueba1DD.Controllers.api
{
    public class ProductController : ApiController
    {
        private BProduct bProduct = new BProduct();

        [ResponseType(typeof(List<Product>))]
        public IHttpActionResult GetProductActivate()
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
            return Ok(response);
        }

        [ResponseType(typeof(List<Product>))]
        public IHttpActionResult GetProductDesactivate()
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
            return Ok(response);
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = bProduct.InsertProduct(new Entity.Product
            {
                ProductName = product.ProductName,
                ProductInventory = product.ProductInventory,
                ProductExpiration = DateTime.ParseExact(product.ProductExpiration, "MM/dd/yyyy", null),
                ProductRegistered = DateTime.ParseExact(product.ProductRegistered, "MM/dd/yyyy HH:mm:ss", null)
            });

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product.ProductID)
            {
                return BadRequest();
            }
            bool result = bProduct.UpdateProduct(new Entity.Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductInventory = product.ProductInventory,
                ProductExpiration = DateTime.ParseExact(product.ProductExpiration, "MM/dd/yyyy", null),
                ProductRegistered = DateTime.ParseExact(product.ProductRegistered, "MM/dd/yyyy HH:mm:ss", null)
            });
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductDesactivate(int id)
        {
            bool result = bProduct.UpdateProductDesactivate(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductActivate(int id)
        {
            bool result = bProduct.UpdateProductActivate(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProduct(int id)
        {
            bool result = bProduct.DeleteProduc(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
