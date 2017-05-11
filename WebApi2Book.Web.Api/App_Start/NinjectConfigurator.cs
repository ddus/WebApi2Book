﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using log4net.Config;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using WebApi2Book.Data.SqlServer.Mapping;

using WebApi2Book.Common;
using WebApi2Book.Common.Logging;
using WebApi2Book.Common.Security;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.QueryProcessors;
using WebApi2Book.Data.SqlServer.QueryProcessors;
using WebApi2Book.Web.Common;
using WebApi2Book.Web.Common.Security;

using WebApi2Book.Web.Api.AutoMappingConfiguration;
using WebApi2Book.Web.Api.MaintenanceProcessing;

namespace WebApi2Book.Web.Api
{
  public class NinjectConfigurator
  {
    private ISession CreateSession(IContext context)
    {
      var sessionFactory = context.Kernel.Get<ISessionFactory>();
      if (!CurrentSessionContext.HasBind(sessionFactory))
      {
        var session = sessionFactory.OpenSession();
        CurrentSessionContext.Bind(session);
      }
      return sessionFactory.GetCurrentSession();
    }

    private void ConfigureNHibernate(IKernel container)
    {
      ISessionFactory sessionFactory = Fluently.Configure()
        .Database(
          MsSqlConfiguration
          .MsSql2012.ConnectionString(
              c => c.FromConnectionStringWithKey("WebApi2BookDb")))
          .CurrentSessionContext("web")
          .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
          .BuildSessionFactory();
      container.Bind<ISessionFactory>()
        .ToConstant(sessionFactory);
      container.Bind<ISession>()
        .ToMethod(CreateSession)
        .InRequestScope();
      container.Bind<IActionTransactionHelper>()
        .To<ActionTransactionHelper>()
        .InRequestScope();
    }

    private void ConfigureLog4Net(IKernel container)
    {
      XmlConfigurator.Configure();
      var logManager = new LogManagerAdapter();
      container.Bind<ILogManager>()
        .ToConstant(logManager);
    }

    private void ConfigureUserSession(IKernel container)
    {
      var userSession = new UserSession();
      container.Bind<IUserSession>()
        .ToConstant(userSession);
      container.Bind<IWebUserSession>()
        .ToConstant(userSession);
    }
    private void ConfigureAutoMapper(IKernel container)
    {
      container.Bind<IAutoMapper>()
        .To<AutoMapperAdapter>()
        .InSingletonScope();

      container.Bind<IAutoMapperTypeConfigurator>()
        .To<StatusEntityToStatusAutoMapperTypeConfigurator>()
        .InSingletonScope();

      container.Bind<IAutoMapperTypeConfigurator>()
        .To<StatusToStatusEntityAutoMapperTypeConfigurator>()
        .InSingletonScope();

      container.Bind<IAutoMapperTypeConfigurator>()
        .To<UserEntityToUserAutoMapperTypeConfigurator>()
        .InSingletonScope();
      container.Bind<IAutoMapperTypeConfigurator>()
        .To<UserToUserEntityAutoMapperTypeConfigurator>()
        .InSingletonScope();

      container.Bind<IAutoMapperTypeConfigurator>()
        .To<NewTaskToTaskEntityAutoMapperTypeConfigurator>()
        .InSingletonScope();
      container.Bind<IAutoMapperTypeConfigurator>()
        .To<TaskEntityToTaskAutoMapperTypeConfigurator>()
        .InSingletonScope();
    }

    private void AddBindings(IKernel container)
    {
      ConfigureLog4Net(container);
      ConfigureNHibernate(container);
      ConfigureUserSession(container);
      ConfigureAutoMapper(container);

      container.Bind<IDateTime>()
        .To<DateTimeAdapter>().InSingletonScope();
      container.Bind<IAddTaskQueryProcessor>()
        .To<AddTaskQueryProcessor>().InRequestScope();
      container.Bind<IAddTaskMaintenanceProcessor>()
        .To<AddTaskMaintenanceProcessor>().InRequestScope();
    }

    public void Configure(IKernel container)
    {
      AddBindings(container);
    }
  }
}