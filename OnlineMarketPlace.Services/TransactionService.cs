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
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTransaction(TransactionCreate trans)
        {
            var entity = new Transaction()
            {
                Id = trans.Id,
                Cost = trans.Cost,
                PersonId = trans.PersonId,
                //ProductId = trans.ProductId
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
                    .Where(e => e.TransactionId == _userId)
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
                      .Single(e => e.Id == id && e.TransactionId == _userId);
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
                    .Single(e => e.Id == trans.Id && e.TransactionId == _userId);

                entity.Id = trans.Id;
                entity.Cost = trans.Cost;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.PersonId = trans.PersonId;
                //entity.ProductId = trans.ProductId;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Transactions
                    .Single(e => e.Id == id && e.TransactionId == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}