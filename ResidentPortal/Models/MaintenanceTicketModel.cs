using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResidentPortal.Models
{
    public class MaintenanceTicketModel
    {
        public string Severity { get; set; }
        public string Area { get; set; }
        public string Req_Date { get; set; }
        public string Details { get; set; }
    }
}