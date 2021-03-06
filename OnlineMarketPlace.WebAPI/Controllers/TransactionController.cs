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
    [Authorize(Roles ="Admin")]
    public class TransactionController : ApiController
    {

        /// <summary>
        /// Returns a detailed list of existing Transactions
        /// </summary>
        /// <returns>
        /// int, double, DateTimeOffset, DateTimeOffset?
        /// </returns>

        public IHttpActionResult Get()
        {
            TransactionService transactionService = CreateTransactionService();
            var transaction = transactionService.GetTransaction();
            return Ok(transaction);
        }
        /// <summary>
        /// Creates a new Transaction in the database.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns>
        /// 
        /// </returns>
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
            var Id = Guid.Parse(User.Identity.GetUserId());
            var transactionService = new TransactionService(Id);
            return transactionService;
        }
        /// <summary>
        /// Allows updates for an existing Transaction.
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IHttpActionResult Put(TransactionEdit trans)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService();

            if (!service.UpdateTransaction(trans))
                return InternalServerError();

            return Ok();
        }
        /// <summary>
        /// Deletes an existing Transaction.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTransactionService();

            if (!service.DeleteTransaction(id))
                return InternalServerError();

            return Ok();
        }
    }
}