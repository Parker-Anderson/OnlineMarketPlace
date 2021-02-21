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
                Cost = trans.Cost
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
                        Cost = e.Cost,
                        CreatedUtc = e.CreatedUtc
                    }
                    );

                return query.ToArray();
            }
        }
        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                      .Transactions
                      .Single(e => e.Id == id && e.Id == _userId);
                return new TransactionDetail
                {
                    Id = entity.Id,
                    Cost = entity.Cost,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
        public bool UpdateTransaction(TransactionEdit trans)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Transactions
                    .Single(e => e.Id == trans.Id && e.Id == _userId);

                entity.Id = trans.Id;
                entity.Cost = trans.Cost;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Transactions
                    .Single(e => e.Id == id && e.Id == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}