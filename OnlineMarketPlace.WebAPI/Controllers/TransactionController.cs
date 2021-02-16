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
    public class TransactionController : ApiController
    {
        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransaction();
            return Ok(transaction);
        }
        public IHttpActionResult Post(TransactionCreate transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.CreateTransaction(transaction))
                return InternalServerError();

            return Ok();
        }
        private TransactionService CreateTransactionService()
        {
            var Id = int.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(Id);
            return transactionService;
        }
    }
}
