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
        public int? PersonId { get; set; }
        public int? ProductId { get; set; }
        // Anything else?

    }
}