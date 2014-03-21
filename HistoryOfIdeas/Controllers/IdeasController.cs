using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.UI.WebControls;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.Controllers
{
    public class IdeasController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IIdeaService _ideaService;

        public IdeasController(IUserService userService, IIdeaService ideaService)
        {
            _userService = userService;
            _ideaService = ideaService;
        }

        //public IdeasController()
        //{
        //}

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Idea> Get()
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                return user.Ideas;
            }
            return new List<Idea>();
        }

        // GET api/<controller>/5
        [HttpGet]
        public Idea Get(int id)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                return user.Ideas.FirstOrDefault(i => i.Id == id);
            }
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        [AcceptVerbs("Post")]
        public Idea Post(string newIdea)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            _ideaService.CreateIdea(new Idea() { Text = newIdea, User = user });
            return user.Ideas.FirstOrDefault(i => i.Text == newIdea);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);

            if (user == null)
            {
                return;
            }

            if (user.Ideas.FirstOrDefault(i => i.Id == id) != null)
            {
                _ideaService.DeleteIdea(id);
            }
        }
    }
}