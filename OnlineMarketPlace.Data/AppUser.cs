using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Data
{
    public class AppUser : IdentityUserRoleConfiguration
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
    public class Buyer : AppUser
    {
        public AppUser user;
        public bool IsBuyer(UserRole role)
        {
            if (user.Role != UserRole.Buyer)
            {
                return false;
            }
            return true;
        }
        
    }
    public class Seller : AppUser
    {

        public AppUser user;
        public bool IsSeller(UserRole role)
        {
            if (user.Role != UserRole.Buyer)
            {

                return true;
            }
            return false;
        }
       // public IdentityUserRoleConfiguration RoleConfiguration()
        
         
        

    }

}