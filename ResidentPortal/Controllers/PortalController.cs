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
            return View();
        }
        //POST: SubmitTicket
        [HttpPost]
        public ActionResult SubmitTicket(MaintenanceTicketModel ticket)
        {            
            if (ModelState.IsValid)
            {
                _Db.Tickets.Add(ticket);
                _Db.SaveChanges();
            }
            return View();
        }
    }
}