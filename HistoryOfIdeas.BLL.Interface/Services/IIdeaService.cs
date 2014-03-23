using System.Collections.Generic;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.BLL.Interface.Services
{
    public interface IIdeaService
    {
        IEnumerable<Idea> Ideas { get; }
        void CreateIdea(Idea newIdea);
        void EditIdea(Idea idea);
        void DeleteIdea(int ideaId);
        Idea GetIdeaById(int ideaId);

    }
}
