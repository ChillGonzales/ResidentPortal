using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResidentPortal.Models;

namespace ResidentPortal.Controllers
{
    public class PortalController : Controller
    {
        PortalContext _Db = new PortalContext();

        // GET: Portal
        public ActionResult Home()
        {
            return View();
        }
        //GET: About
        public ActionResult About()
        {
            return View();
        }
        //GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        //GET: SubmitTicket
        [HttpGet]
        public ActionResult SubmitTicket()
        {            
            return View(_Db.Tickets.ToList());
        }
        //POST: SubmitTicket
        [HttpPost]
        public ActionResult SubmitTicket(FormCollection form)
        {
            var ticketToAdd = new MaintenanceTicketModel();
            ticketToAdd.Area = form["area-select"];
            ticketToAdd.Details = form["details"];
            ticketToAdd.Severity = form["severity-select"];
            ticketToAdd.Req_Date = form["date"];                        
            if (ModelState.IsValid)
            {
                _Db.Tickets.Add(ticketToAdd);
                _Db.SaveChanges();
            }
            return View(_Db.Tickets.ToList());
        }
    }
}