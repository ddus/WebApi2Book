using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http.Dependencies;

namespace WebApi2Book.Web.Common
{
  public sealed class NinjectDependencyResolver : IDependencyResolver, IDependencyScope
  {
    private readonly IKernel _container;

    public IKernel Container
    {
      get { return _container; }
    }

    public IDependencyScope BeginScope()
    {
      return (IDependencyScope)this;
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public object GetService(Type serviceType)
    {
      var service = _container.TryGet(serviceType);
      return service;
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      var services = _container.GetAll(serviceType);
      return services;
    }

    public NinjectDependencyResolver(IKernel container)
    {
      _container = container;
    }
  }
}
