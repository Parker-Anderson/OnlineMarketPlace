using Microsoft.AspNet.Identity;
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
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()

        {


            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService();
            return categoryService;

        }
        /// <summary>
        /// Returns a detailed list of existing Categories.
        /// </summary>
        /// <returns>
        /// int, string, CategoryType, double, double
        /// </returns>
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }
        /// <summary>
        /// Creates a new Category in the database.
        /// </summary>
        /// <param name="category"></param>
        /// <returns>
        /// string
        /// </returns>

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Allows updates for existing Category.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="categoryId"></param>
        /// <returns>
        /// 
        /// </returns>
        public IHttpActionResult Put(CategoryEdit category, int categoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category, categoryId))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Deletes an existing Category.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }

    }
}
