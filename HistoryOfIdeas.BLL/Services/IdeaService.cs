using System;
using System.Collections.Generic;
using System.Linq;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.DAL.Interface.Repositories;

namespace HistoryOfIdeas.BLL.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IIdeaRepository _ideaRepository;

        public IdeaService(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public IEnumerable<Idea> Ideas {
            get { return _ideaRepository.All; }
        }
        

        public void CreateIdea(Idea newIdea)
        {
            _ideaRepository.InsertOrUpdate(newIdea);
            _ideaRepository.Save();
        }

        public void EditIdea(Idea idea)
        {
            _ideaRepository.InsertOrUpdate(idea);
            _ideaRepository.Save();
        }

        public void DeleteIdea(int ideaId)
        {
            _ideaRepository.Delete(ideaId);
            _ideaRepository.Save();
        }


        public Idea GetIdeaById(int ideaId)
        {
            return _ideaRepository.Find(ideaId);
        }
    }
}
