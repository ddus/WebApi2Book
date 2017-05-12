using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
//using WebApi2Book.Data.Entities;
//using WebApi2Book.Data.Entities;
using WebApi2Book.Web.Common;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class StatusEntityToStatusAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator, IAutoMapperTypeConfigurator2
  {
    public void Configure()
    {
      Mapper.CreateMap<Data.Entities.Status, Models.Status>();
    }

    public void Configure(IConfiguration cfg)
    {
      cfg.CreateMap<Data.Entities.Status, Models.Status>();
    }
  }
}