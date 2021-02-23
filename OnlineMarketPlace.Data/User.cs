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
        public int ID { get; set; }

        public int integer { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public virtual Transaction Transaction { get; set; }
        public DateTime DateJoined { get; set; }
        [Required]
        public string UserRole { get; set; }
        public Guid UserID { get; set; }
        //public UserRole Role { get; set; }
        //public enum UserRole
        //{
        //  Buyer = 1,
        //  Seller
        //}
    }

}