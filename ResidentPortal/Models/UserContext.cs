using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Entity;

namespace ResidentPortal.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("RPContext")
        {
            Database.SetInitializer<UserContext>(null);
        }

        public UserContext Create()
        {
            return new UserContext();
        }

        public DbSet<UserModel> Users;

    }
}