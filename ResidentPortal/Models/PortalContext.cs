using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Entity;

namespace ResidentPortal.Models
{
    public class PortalContext : DbContext
    {
        public PortalContext() : base("RPContext")
        {
            Database.SetInitializer<PortalContext>(null);
        }

        public PortalContext Create()
        {
            return new PortalContext();
        }

        public DbSet<MaintenanceTicketModel> Tickets { get; set; }
        public DbSet<UserModel> Users { get; set; }
       
        private volatile Type _dependency;
        public void MyContext()
        {
             _dependency = typeof(MySql.Data.MySqlClient.MySqlProviderServices);            
        }
    }
}