using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double PriceRange { get; set; }

        public double Popularity { get; set; }
    }
}
