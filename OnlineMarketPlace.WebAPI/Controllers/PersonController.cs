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
    [Authorize]
    public class PersonController : ApiController
    {
        /// <summary>
        /// Returns a detailed list of existing Persons.
        /// </summary>
        /// <returns>
        /// string, string, DateTime, string
        /// </returns>
        public IHttpActionResult Get()
        {
            PersonService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        /// <summary>
        /// Creates a new Person in the database.
        /// </summary>
        /// <param name="user"></param>
        /// 
        /// <returns></returns>
        public IHttpActionResult Post(PersonCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserService();
            if (!service.CreateUser(user))
                return InternalServerError();
            return Ok();
        }
        private PersonService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new PersonService(userId);
            return userService;
        }
        /// <summary>
        /// Returns an existing Person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// int, string, string, DateTime, string
        /// </returns>
        public IHttpActionResult Get(int id)
        {
            PersonService userService = CreateUserService();
            var user = userService.GetUserById(id);
            return Ok(user);
        }
        /// <summary>
        /// Allows updates for an existing Person.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IHttpActionResult Put(PersonEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserService();
            if (!service.UpdateUser(user))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Deletes an existing Person.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();
            if (!service.DeleteUser(id))
                return InternalServerError();
            return Ok();
        }


    }
}