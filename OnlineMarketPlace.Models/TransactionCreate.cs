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
        [Required]
        public double Amount { get; set; }
        // Add anything else?


    }
}
