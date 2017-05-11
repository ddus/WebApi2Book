using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class TestEntityToTestAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<WebApi2Book.Data.Entities.Test, Models.Test>();
          //.ForMember(opt => opt.TestIgnore, x => x.Ignore());
      });
    }
  }
}