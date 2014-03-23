using System.Collections.Generic;
using System.Linq;

namespace HistoryOfIdeas.DAL.Interface.Repositories
{
    public interface IRepository<T>
		where T : class
	{
		IEnumerable<T> All { get; }

		T Find(int id);

		void InsertOrUpdate(T obj);

		void Delete(int id);

		void Save();
	};
}
