using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResidentPortal.Models;
using System.Threading.Tasks;
using ResidentPortal.Enumeration;

namespace ResidentPortal.Controllers
{
    public class PortalController : Controller
    {
        PortalContext _Db = new PortalContext();
        UserModel _CurrentUser = new UserModel();

        // GET: Portal
        public ActionResult Home(UserModel userMod)
        {
            if (userMod != null)
            {
                return View(userMod);
            }
            return View();
        }
        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(FormCollection form)
        {
            var UserToAdd = new UserModel()
            {
                FirstName = form["firstname"],
                LastName = form["lastname"],
                Email = form["email"],
                PhoneNumber = form["phonenumber"],
                UserName = form["username"],
                PasswordHash = form["pwd"].GetHashCode().ToString(),     
                LockoutEndDateUTC = DateTime.UtcNow.AddDays(30).ToString()
            };
            var validateState = await UserModel.ValidateNewUser(_Db, UserToAdd);
            if (validateState == NewUserValidationState.EmailFailed)
            {
                ViewBag.Message = "Email Address is Already Registered With An Account. Click Above To Recover Your Password.";                
            }
            else if(validateState== NewUserValidationState.UsernameFailed)
            {
                ViewBag.Message = "User Name is Already Registered. Please Select A Different User Name and Try Again.";
            }
            else if (validateState == NewUserValidationState.Approved && ModelState.IsValid)
            {
                _Db.Users.Add(UserToAdd);
                _Db.SaveChanges();
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult NavBarLayout()
        {
            return View(_CurrentUser);
        }
        //GET: CreateUser
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            var currentUser = UserModel.ValidateUser(ref _Db, form["username"], form["pwd"].GetHashCode().ToString());
            if (currentUser == null)
            {
                return View("LoginFail");
            }
            _CurrentUser = currentUser;
            return View("Home", _CurrentUser);
        }
        public ActionResult Logout()
        {
            _CurrentUser = new UserModel();
            return View("Home", _CurrentUser);
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
            ViewBag.User = _CurrentUser;
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
            message.Body = form["msgbody"];
            message.SendMessage();
            return View(message);
        }
    }
}