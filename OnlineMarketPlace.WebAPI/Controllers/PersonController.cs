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
        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var users = personService.GetPersons();
            return Ok(users);
        }
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
        public IHttpActionResult Get(int id)
        {
            PersonService userService = CreatePersonService();
            var user = userService.GetPersonById(id);
            return Ok(user);
        }
        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.UpdatePerson(person))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePersonService();
            if (!service.DeletePerson(id))
                return InternalServerError();
            return Ok();
        }


    }
}