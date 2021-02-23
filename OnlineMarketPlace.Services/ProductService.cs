using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class ProductService
    {
        public IEnumerable<ProductListItem> GetProduct()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.ProductId == _productId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    Id = e.ID,
                                    Name = e.Name,
                                    Price = e.Price
                                }
                        );

                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId  == _productId);
                return
                    new ProductDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Price = entity.Price,
                        HowLongOnMarket = entity.HowLongOnMarket,
                        Description = entity.Description
                    };
            }
        }
        private readonly Guid _productId;

        public ProductService(Guid productId)
        {
            _productId = productId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {

                    Name = model.Name,
                    Price = model.Price
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
    }

}