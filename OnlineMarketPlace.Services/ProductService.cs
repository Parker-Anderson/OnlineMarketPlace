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
        //private readonly Guid _productId;

        public ProductService(Guid productId)
        {
       //     _productId = productId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {

                    Name = model.Name,
                    Price = model.Price,
                    PersonId = model.PersonId,
                    CategoryId = model.CategoryId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
    }

}