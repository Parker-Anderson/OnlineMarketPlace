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
    [Authorize]
    public class ProductController : ApiController
    {
        public IHttpActionResult Get()
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProduct();
            return Ok(product);
        }
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
            var productId = int.Parse(User.Identity.GetUserId());
            var productService = new ProductService(productId);
            return productService;
        }
    }
}