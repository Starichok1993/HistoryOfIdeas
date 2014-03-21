using System;
using System.Web.Mvc;
using System.Web.Routing;
using HistoryOfIdeas.IoC.DependencyInjection;
using Ninject;

namespace HistoryOfIdeas.Infrastructure
{
    public class NinjectFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel = new HistoryOfIdeasKernel();
     //   public IKernel _kernel = new HistoryOfIdeasKernel();

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)_kernel.Get(controllerType);
        }
    }
}