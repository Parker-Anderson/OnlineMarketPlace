using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineMarketPlace.Data.User;

namespace OnlineMarketPlace.Models
{
    public class UserListItem
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Joined")]
        public DateTime DateJoined { get; set; }
        public UserRole Role { get; set; }

    }
}
