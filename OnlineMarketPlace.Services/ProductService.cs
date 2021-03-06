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
        public ProductService(Guid id)
        {

        }
        public IEnumerable<ProductListItem> GetProduct()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        //.Where(e => e.ProductId == _productId)
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
                .Single(e => e.ID == id);
                return
                    new ProductDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        Price = entity.Price,
                        HowLongOnMarket = entity.HowLongOnMarket,
                        Description = entity.Description,
                        CategoryId = entity.CategoryId
                    };
            }


        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {

                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    PersonId = model.PersonId,
                    CategoryId = model.CategoryId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ID == model.IdOfProduct);

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Description = model.Description;


                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ID == productId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}