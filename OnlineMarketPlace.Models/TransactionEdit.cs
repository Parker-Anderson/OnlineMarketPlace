using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class TransactionEdit
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int? PersonID { get; set; }
        public int? IdOfProduct { get; set; }


        // Anything else?

    }
}