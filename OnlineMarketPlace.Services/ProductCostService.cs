using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class ProductCostService
    {
        private readonly Product product;
        public bool CreateProductCost(ProductCostCreate productCostCreate)
        {
            var entity = new ProductCost()
            {
                _product = product,
                Price = product.Price,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductCosts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
