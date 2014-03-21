using System.Data.Entity;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.DAL.Interface.DbContext
{
    public interface IHistoryOfIdeasDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Idea> Ideas { get; set; }
    }
}
