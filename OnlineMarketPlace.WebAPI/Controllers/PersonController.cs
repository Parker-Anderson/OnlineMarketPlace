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
            PersonService personService = CreatePersonService();
            var persons = personService.GetPersons();
            return Ok(persons);
        }
        /// <summary>
        /// Creates a new Person in the database.
        /// </summary>
        /// <param name="person"></param>
        /// 
        /// <returns></returns>
        public IHttpActionResult Post(PersonCreate person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.CreatePerson(person))
                return InternalServerError();
            return Ok();
        }
        private PersonService CreatePersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var personService = new PersonService(userId);
            return personService;
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
            PersonService userService = CreatePersonService();
            var user = userService.GetPersonById(id);
            return Ok(user);
        }
        /// <summary>
        /// Allows updates for an existing Person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.UpdatePerson(person))
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
            var service = CreatePersonService();
            if (!service.DeletePerson(id))
                return InternalServerError();
            return Ok();
        }
    }
}