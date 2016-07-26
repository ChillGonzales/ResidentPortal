using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResidentPortal.Models
{
    [Table("maint_ticket")]    
    public class MaintenanceTicketModel
    {
        [Key]
        public int ID { get; set; }
        public string Severity { get; set; }
        public string Area { get; set; }
        public string Req_Date { get; set; }
        public string Details { get; set; }
        public string timeSubmit { get; set; }
        public string ticketClosed { get; set; }
    }
}