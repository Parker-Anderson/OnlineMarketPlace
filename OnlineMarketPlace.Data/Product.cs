using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{

    public class Product
    {


        [Key]
        public int IdOfProduct { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan HowLongOnMarket { get; set; }

        public string Description { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(User))]
        public int? PersonID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId {get; set;}
        public virtual Category Category {get; set;}


    }
}