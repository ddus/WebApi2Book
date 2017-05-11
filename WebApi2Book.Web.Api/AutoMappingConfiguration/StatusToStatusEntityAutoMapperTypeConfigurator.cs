using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;
using WebApi2Book.Web.Common;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class StatusToStatusEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      /*
      Mapper.CreateMap<Models.Status, Data.Entities.Status>()
          .ForMember(opt => opt.Version, x => x.Ignore());
          */
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Models.Status, Data.Entities.Status>()
          .ForMember(dest => dest.Version, opt => opt.Ignore());
      });
    }
  }
}