using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Models
{
    public class UserEdit
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public DateTime DateJoined { get; set; }
        public Guid UserID { get; set; }
    }
}