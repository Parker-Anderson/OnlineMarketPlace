﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int? ProductId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public enum PaymentMethod
        {
            CreditCard = 1,
            DebitCard,
            GiftCard,
            PayPal
        }

        //public string UserRole { get; set; } 
        //Transaction assigned to buyer and/or seller?
    }
}
