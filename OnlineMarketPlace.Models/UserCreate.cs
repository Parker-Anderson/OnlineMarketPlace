using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineMarketPlace.Data.User;

namespace OnlineMarketPlace.Models
{
    public class UserCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public DateTime DateJoined { get; set; }

    }
}
