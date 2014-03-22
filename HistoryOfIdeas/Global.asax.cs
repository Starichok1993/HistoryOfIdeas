using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HistoryOfIdeas.App_Start;
using HistoryOfIdeas.Infrastructure;
using HistoryOfIdeas.IoC.DependencyInjection;

namespace HistoryOfIdeas
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //add custom database initializer
            //Database.SetInitializer(new HistoryOfIdeasDbInitializer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           
            ControllerBuilder.Current.SetControllerFactory(new NinjectFactory());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(new HistoryOfIdeasKernel());

            

        }
    }
}
