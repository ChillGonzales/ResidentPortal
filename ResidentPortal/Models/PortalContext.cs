using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Configuration;
using System.Data.Entity;

namespace ResidentPortal.Models
{
    public class PortalContext : DbContext
    {
        public PortalContext() : base("RPContext")
        {

        }

        public PortalContext Create()
        {
            return new PortalContext();
        }

        public DbSet<MaintenanceTicketModel> Tickets { get; set; }
        


        //public string SelectDB(string selectField)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["RPContext"].ConnectionString))
        //        {
        //            connection.Open();
        //            using (OdbcCommand command = new OdbcCommand(String.Format("SELECT {0} FROM maint_ticket", selectField), connection))
        //            using (OdbcDataReader dr = command.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                    result = dr.GetString(0);
        //                dr.Close();
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "An error occured: " + ex.ToString();
        //    }
        //    return result;
        //}        

    }
}