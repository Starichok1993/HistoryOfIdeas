using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HistoryOfIdeas.DAL.Entity;


namespace HistoryOfIdeas.DAL.DbContext
{
    public class HistoryOfIdeasContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }

        public HistoryOfIdeasContext() : base("HistoryOfIdeaContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove
                <OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
