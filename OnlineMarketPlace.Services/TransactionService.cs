using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class TransactionService
    {
        private readonly int _userId;

        public TransactionService(int userId)
        {
            _userId = userId;
        }
        public bool CreateTransaction(TransactionCreate trans)
        {
            var entity = new Transaction()
            {
                Id = _userId,
                Amount = trans.Amount
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionListItem> GetTransaction()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Transactions
                    .Where(e => e.Id == _userId)
                    .Select(e => new TransactionListItem
                    {
                        Id = e.Id,
                        Amount = e.Amount,
                        CreatedUtc = e.CreatedUtc
                    }
                    );
                    
                return query.ToArray();
            }
        }
    }
}

