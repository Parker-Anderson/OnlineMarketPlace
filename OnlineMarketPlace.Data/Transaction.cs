﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public enum PaymentMethod
        {
            CreditCard = 1,
            DebitCard,
            GiftCard,
            PayPal
        }

    

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }


       // [ForeignKey(nameof(Product))]
        public double Cost { get; set; }
        public virtual Product Product { get; set; }

        //[ForeignKey(nameof(Product))]
       // public double Cost { get; set; }
        //public virtual Product Product { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
