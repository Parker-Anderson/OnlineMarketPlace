using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class TransactionCreate
    {
        [Required]
        public int Id { get; set; }

        public decimal Cost { get; set; }
        public int IdOfProduct { get; set; }
        public int? PersonID { get; set; }
        // Add anything else?


    }
}
