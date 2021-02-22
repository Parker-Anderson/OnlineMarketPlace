using OnlineMarketPlace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class CategoryDetail
    {

        public int CategoryId { get; set; }
        public CategoryType Name { get; set; }
        public double Popularity { get; set; }

        public double PriceRange { get; set; }


    }
}
