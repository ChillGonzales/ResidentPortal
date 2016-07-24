using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResidentPortal.Controllers
{
    public class PortalController : Controller
    {
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
        public ActionResult SubmitTicket()
        {
            return View();
        }
    }
}