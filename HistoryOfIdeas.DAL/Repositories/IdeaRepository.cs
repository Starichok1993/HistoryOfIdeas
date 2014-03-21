using HistoryOfIdeas.DAL.DbContext;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.DAL.Interface.Repositories;

namespace HistoryOfIdeas.DAL.Repositories
{
    public class IdeaRepository : HistoryOfIdeasRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(HistoryOfIdeasContext context) : base(context)
        {
        }
    }
}
