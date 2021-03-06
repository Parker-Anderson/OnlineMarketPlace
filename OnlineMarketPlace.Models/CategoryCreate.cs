using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    //public enum CategoryType
    // {
     //   Books,
      //  Toys,
      //  HomeAndGarden,
      //  Electronics,
      //  Clothing,
      //  Sports,
      //  Beauty,

   // }
    public class CategoryCreate
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }

        public double PriceRange { get; set; }

        // convert date to enum when saved in database

    }
}