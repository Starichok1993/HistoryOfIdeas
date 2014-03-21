using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.BLL.Services;
using HistoryOfIdeas.DAL.DbContext;
using HistoryOfIdeas.DAL.Interface.Repositories;
using HistoryOfIdeas.DAL.Repositories;
using Ninject;

namespace HistoryOfIdeas.IoC.DependencyInjection
{
    public class HistoryOfIdeasKernel : StandardKernel
    {
        
		public HistoryOfIdeasKernel()
		{
			AddBindings();
		}

		private void AddBindings()
		{
			//repositories bindings
			//KernelInstance.Bind()<HistoryOfIdeasContext>().ToSelf();

		    Bind<IUserRepository>().To<UserRepository>();
		    Bind<IIdeaRepository>().To<IdeaRepository>();
			
			//business logic bindings
			Bind<IUserService>().To<UserService>();
			Bind<IIdeaService>().To<IdeaService>();
		}

    }
}
