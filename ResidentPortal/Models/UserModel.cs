using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResidentPortal.Models
{
    [Table("UserTable")]
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LockoutEndDateUTC { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static UserModel ValidateUser(ref PortalContext DB, string user, string pwdhash)
        {
            var query = from s in DB.Users where (s.UserName.ToLower() == user.ToLower() && s.PasswordHash.ToLower() == pwdhash.ToLower()) select s;
            UserModel UserResult;
            try
            {
                UserResult = query.First();
            }
            catch
            {
                return null;
            }

            if (UserResult != null)
            {
                return UserResult;
            }
            return null;
        }
    }    
}