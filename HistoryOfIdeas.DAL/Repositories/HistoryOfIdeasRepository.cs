using System.Data.Entity;
using System.Linq;
using HistoryOfIdeas.DAL.DbContext;
using HistoryOfIdeas.DAL.Entity.Interface;
using HistoryOfIdeas.DAL.Interface.Repositories;

namespace HistoryOfIdeas.DAL.Repositories
{
    /*
     * Template for other repository that use HistoryOfIdeaContext
     */
    public class HistoryOfIdeasRepository<T>:IRepository<T>
		where T : class, IEntity, new()
    {
        protected readonly HistoryOfIdeasContext Context;
		protected readonly DbSet<T> DbSet;

        public HistoryOfIdeasRepository(HistoryOfIdeasContext context)
		{
			Context = context;
			DbSet = context.Set<T>();
		}

		public IQueryable<T> All
		{
			get { return DbSet; }
		}

		public T Find(int id)
		{
			return DbSet.Find(id);
		}
        
		public void InsertOrUpdate(T obj)
		{
			Context.Entry(obj).State = obj.Id == 0 ?
										EntityState.Added :
										EntityState.Modified;
		}

		public void Delete(int id)
		{
			T obj = DbSet.Find(id);
		    if (obj != null)
		    {
		        DbSet.Remove(obj);
		    }
		}

		public void Save()
		{
			Context.SaveChanges();
		}

	};
}
