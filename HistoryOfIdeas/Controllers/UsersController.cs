using System.Web.Mvc;
using HistoryOfIdeas.BLL.Interface.Services;

namespace HistoryOfIdeas.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {

            return View(_userService.Users);
        }

    }
}