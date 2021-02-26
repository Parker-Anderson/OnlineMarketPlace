using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{
    public class ProductCost
    {
        public Product product1;
        public Product Product(int? id, decimal? price)
        {
            id = product1.ID;
            price = product1.Price;

            return product1;
        }
        
        
      

        public int? RefId { get; set; }
        public decimal? ProductPrice { get; set; }

        public ProductCost()
        {
            RefId = product1.ID;
            ProductPrice = product1.Price;

        }
    }
}
