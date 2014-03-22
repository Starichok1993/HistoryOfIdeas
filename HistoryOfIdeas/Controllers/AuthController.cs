using System.Web.Mvc;
using System.Web.Security;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.Helpers;

namespace HistoryOfIdeas.Controllers
{
    public class AuthController : Controller
    {
        //
        // GET: /LogIn/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("LogIn");
        }
        
        public ActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserAuth user)
        {
            if (ModelState.IsValid)
            {
                if (((HistoryOfIdeasMembershipProvider)Membership.Provider).ValidateUser(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, user.RememberMe);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Wrong email or pass");
            }
            return View(user);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserReg user)
        {

            if (ModelState.IsValid)
            {
                MembershipUser membershipUser = ((HistoryOfIdeasMembershipProvider)Membership.Provider).
                    CreateUser(user.Email, user.Password, user.Name, user.Surname);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Registration Error");
            }
            return View(user);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}