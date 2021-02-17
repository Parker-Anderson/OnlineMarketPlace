using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{
    public enum ShoppingCategory
    {
        Clothing = 1,
        Electronics,
        Home,
        Kids,
        Outdoor,
        Art
    }
    public class Product
    {


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan HowLongOnMarket { get; set; }
        public ShoppingCategory Category { get; set; }
        public string Description { get; set; }

        //[ForeignKey(nameof(User)))]
        // public int UserId { get; set; }
        //public virtual User UserId {get; set;}

    }
}
