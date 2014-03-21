using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.BLL.Interface.Services
{
    public interface IIdeaService
    {
        IQueryable<Idea> Ideas { get; }
        void CreateIdea(Idea newIdea);
        void EditIdea(Idea idea);
        void DeleteIdea(int ideaId);
        Idea GetIdeaById(int ideaId);

    }
}
