using BusinessLayer;
using DataLayer;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace PulseEnergy
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
        }

        private void AddBindings(IKernel kernel)
        {
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            kernel.Bind<IUserBusiness>().To<UserBusiness>().InSingletonScope();
            kernel.Bind<ISpendingRepository>().To<SpendingRepository>().InSingletonScope();
            kernel.Bind<ISpendingBusiness>().To<SpendingBusiness>().InSingletonScope();
            return kernel;
        }
    }
}