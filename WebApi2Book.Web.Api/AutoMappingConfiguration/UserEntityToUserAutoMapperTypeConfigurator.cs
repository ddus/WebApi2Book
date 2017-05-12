using System;
using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator, IAutoMapperTypeConfigurator2
  {
    public void Configure()
    {
      Mapper.CreateMap<Data.Entities.User, Models.User>()
        .ForMember(dest => dest.Links, opt => opt.Ignore());
    }

    public void Configure(IConfiguration cfg)
    {
      cfg.CreateMap<Data.Entities.User, Models.User>()
        .ForMember(dest => dest.Links, opt => opt.Ignore());
    }
  }
}