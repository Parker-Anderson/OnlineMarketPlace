using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{

    //public enum CategoryType
  // {
    //    Books=1,
   //    Toys,
   //    HomeAndGarden,
   //     Electronics,
     //   Clothing,
   //     Sports,
   //     Beauty,

  //  }
    public class Category
    {
        public int CategoryId { get; set; }
        public String Name { get; set; }
        public double Popularity { get; set; }

        public double PriceRange { get; set; }
       // public Guid IdOfCategory { get; set; }


    }
}