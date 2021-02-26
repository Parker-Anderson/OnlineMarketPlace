using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{
  
        public class User
        {

            [Key]
            public int PersonId { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public DateTime DateJoined { get; set; }
            public Guid UserID { get; set; }
            [Required]
            public UserRole Role { get; set; }
            public enum UserRole
            {
                Buyer = 1,
                Seller
            }
        }

    }