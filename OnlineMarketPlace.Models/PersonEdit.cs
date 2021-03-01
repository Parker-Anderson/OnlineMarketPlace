using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineMarketPlace.Data.Person;

namespace OnlineMarketPlace.Models
{
    public class PersonEdit
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime DateJoined { get; set; }
        public Guid UserID { get; set; }
    }
}