using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class TestToTestEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Models.Test, Data.Entities.Test>()
          .ForMember(opt => opt.Version, x => x.Ignore())
          .ForMember(opt => opt.TestId, x => x.Ignore())
          .ForMember(opt => opt.CreatedDate, x => x.Ignore())
          .ForMember(opt => opt.TestStatus, x => x.Ignore());
      });
    }
  }
}