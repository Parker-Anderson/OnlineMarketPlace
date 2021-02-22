using Microsoft.Build.Framework.XamlTypes;
using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Category = OnlineMarketPlace.Data.Category;

namespace OnlineMarketPlace.Services
{
    public class CategoryService
    {
       // private readonly Guid _categoryId;

       public CategoryService()
        {
      //      _categoryId = categoryId;
        }


        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    
                    Name = model.Name,
                    
                  
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                      //  .Where(e => e.CategoryId == _categoryId)
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryId = e.CategoryId,
                                    Name = e.Name,
                                   
                                }
                        );

                return query.ToArray();
            }

        }

        public bool UpdateCategory(CategoryEdit model, int categoryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Categories
                            .Single(e => e.CategoryId == model.CategoryId);

                    entity.Name = model.Name;
                    entity.PriceRange = model.PriceRange;
                    

                    return ctx.SaveChanges() == 1;
                }
            }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == categoryId );

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

