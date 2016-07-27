using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using ResidentPortal.Enumeration;

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

        public static async Task<NewUserValidationState> ValidateNewUser(PortalContext DB, UserModel user)
        {                        
            var retVal = await Task.Run<NewUserValidationState>(new Func<NewUserValidationState>(() => 
                {
                    return Query(ref DB, user);
                }));
            return retVal;
        }

        private static NewUserValidationState Query(ref PortalContext DB, UserModel userMod)
        {
            var query_UserName = from s in DB.Users where (s.UserName.ToLower() == userMod.UserName.ToLower()) select s;
            var query_Email = from s in DB.Users where (s.Email.ToLower() == userMod.Email.ToLower()) select s;
            if (query_UserName.Count() > 0)
            {
                //return false if there is already a user with the same username or email
                return NewUserValidationState.UsernameFailed;
            }
            else if (query_Email.Count() > 0)
            {
                return NewUserValidationState.EmailFailed;
            }
            else
            {
                return NewUserValidationState.Approved;
            }
        }
    }    
}