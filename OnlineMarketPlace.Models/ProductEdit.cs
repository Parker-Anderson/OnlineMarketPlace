using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class ProductEdit
    {
        public int IdOfProduct { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

    }
}
