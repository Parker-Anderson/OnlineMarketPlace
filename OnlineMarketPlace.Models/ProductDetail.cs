using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class ProductDetail
    {
        public int IdOfProduct { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan HowLongOnMarket { get; set; }

        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public int? UserID { get; set; }
        public int? CategoryId { get; set; }
    }
}
