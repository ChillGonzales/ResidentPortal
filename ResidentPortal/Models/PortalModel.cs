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
        public static string ConnectDB()
        {
            string word;
            try
            {
                using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["RPContext"].ConnectionString))
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand("SELECT details FROM maint_ticket", connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                            word = dr.GetString(0);
                        dr.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                word = "An error occured: " + ex.ToString();
            }
            finally
            {
                return word;
            }
        }
    }
}