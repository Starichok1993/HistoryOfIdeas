using HistoryOfIdeas.DAL.DbContext;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.DAL.Interface.Repositories;

namespace HistoryOfIdeas.DAL.Repositories
{
    public class UserRepository: HistoryOfIdeasRepository<User>, IUserRepository
    {
        public UserRepository(HistoryOfIdeasContext context) : base(context)
        {
        }
    }
}
