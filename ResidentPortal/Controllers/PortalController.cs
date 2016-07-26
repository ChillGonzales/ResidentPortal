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
        public ActionResult ViewTickets()
        {            
            return View(from s in _Db.Tickets where s.ticketClosed == "false" select s);
        }
        //POST: SubmitTicket
        [HttpPost]
        public ActionResult ViewTickets(FormCollection form)
        {
            var ticketToAdd = new MaintenanceTicketModel();
            ticketToAdd.Area = form["area-select"];
            ticketToAdd.Details = form["details"];
            ticketToAdd.Severity = form["severity-select"];
            ticketToAdd.Req_Date = form["date"];
            ticketToAdd.timeSubmit = DateTime.Now.ToString();
            ticketToAdd.ticketClosed = "false";
            if (ModelState.IsValid)
            {
                _Db.Tickets.Add(ticketToAdd);
                _Db.SaveChanges();
            }
            return View(from s in _Db.Tickets where s.ticketClosed == "false" select s);
        }
        //GET: SendMessage
        [HttpPost]
        public ActionResult MessageSent(FormCollection form)
        {
            var message = new MessageModel();
            message.Subject = form["subject"];
            message.Body = form["body"];
            return View(message);
        }
    }
}