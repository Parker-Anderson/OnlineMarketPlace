using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{

    public enum CategoryType
    {
        Books,
        Toys,
        HomeAndGarden,
        Electronics,
        Clothing,
        Sports,
        Beauty,

    }
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        public CategoryType Name { get; set; }
        public double Popularity { get; set; }

        public double PriceRange { get; set; }


    }
}