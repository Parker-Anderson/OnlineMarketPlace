using Microsoft.AspNet.Identity;
using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using OnlineMarketPlace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineMarketPlace.WebAPI.Controllers
{
    [Authorize(Roles = "Admin, Buyer, Seller")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// Returns a detailed list of existing Products.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProduct();
            return Ok(product);
        }
        /// <summary>
        /// Creates a new Product in the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok();
        }
        private ProductService CreateProductService()
        {
           var productId = Guid.Parse(User.Identity.GetUserId());
            
           var productService = new ProductService(productId);
            return productService;
        }
        /// <summary>
        /// Returns a single Product, specified by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            ProductService productService = CreateProductService();
            var note = productService.GetProductById(id);
            return Ok(note);
        }
  
        /// <summary>
        /// Enables updates for an existing Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Deletes an existing Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();

            return Ok();
        }
    }
}
    
