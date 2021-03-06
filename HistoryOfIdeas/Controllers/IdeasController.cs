﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.Helpers;

namespace HistoryOfIdeas.Controllers
{
    [Authorize]
    public class IdeasController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IIdeaService _ideaService;

        public IdeasController(IUserService userService, IIdeaService ideaService)
        {
            _userService = userService;
            _ideaService = ideaService;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<IdeaViewModel> Get()
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                return  IdeasMapper.MapListToViewModels(user.Ideas.OrderByDescending(y=> y.PublicationTime));
            }
            return new List<IdeaViewModel>();
        }

        // GET api/<controller>/5
        [HttpGet]
        public IdeaViewModel Get(int id)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                return IdeasMapper.MapToViewModel(user.Ideas.FirstOrDefault(i => i.Id == id));
            }
            return null;
        }

        // POST api/<controller>
        [HttpPost]
        public IdeaViewModel Post([FromBody] string value)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);
            if (user != null)
            {
                var time = DateTime.Now;
                _ideaService.CreateIdea(new Idea {Text = value, User = user, PublicationTime = time});


                var idea = user.Ideas.FirstOrDefault(i => i.Text == value && i.PublicationTime == time );


                return IdeasMapper.MapToViewModel(idea);
            }
            return null;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            var user = _userService.GetUserByEmail(User.Identity.Name);

            if (user == null)
            {
                return;
            }

            var idea = user.Ideas.FirstOrDefault(i => i.Id == id);

            if (idea != null)
            {
                idea.Text = value;
                _ideaService.EditIdea(idea);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete([FromBody]int id)
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