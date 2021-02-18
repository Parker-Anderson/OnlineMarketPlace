﻿using Microsoft.AspNet.Identity;
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
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        public IHttpActionResult Post(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateUserService();
            if (!service.CreateUser(user))
                return InternalServerError();
            return Ok();
        }
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }
        
        
    }
}
