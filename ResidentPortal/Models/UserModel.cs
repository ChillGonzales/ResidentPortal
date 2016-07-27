using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ResidentPortal.Models
{
    [Table("UserTable")]
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LockoutEndDateUTC { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
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

        public static async Task<bool> ValidateNewUser(ref PortalContext DB, UserModel user)
        {            
            var _db = DB;
            Func<UserModel, bool> selectorAsync = userMod => Query(ref _db, userMod);
            var retVal = await Task.Run<bool>(new Func<bool>(() => 
                {
                    Query(ref _db, user);
                }));
            return retVal;
        }

        private static bool Query(ref PortalContext DB, UserModel userMod)
        {
            var query = from s in DB.Users where (s.UserName.ToLower() == userMod.UserName.ToLower() || s.Email.ToLower() == userMod.Email.ToLower()) select s;
            if (query.Count() > 0)
            {
                //return false if there is already a user with the same username or email
                return false;
            }
            return true;
        }
    }    
}