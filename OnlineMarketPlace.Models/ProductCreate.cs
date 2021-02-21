﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class ProductCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}