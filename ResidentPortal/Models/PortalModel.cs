using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Configuration;

namespace ResidentPortal.Models
{
    public class PortalModel
    {
        //public static void ConnectDB(string connectStr)
        //{
        //    try
        //    {
        //        using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
        //        {
        //            connection.Open();
        //            using (OdbcCommand command = new OdbcCommand("SELECT name FROM test_users", connection))
        //            using (OdbcDataReader dr = command.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                    Response.Write(dr["name"].ToString() + "<br />");
        //                dr.Close();
        //            }
        //            connection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("An error occured: " + ex.Message);
        //    }
        //}
    }
}