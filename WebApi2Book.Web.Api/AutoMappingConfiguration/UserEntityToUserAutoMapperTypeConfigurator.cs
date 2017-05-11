using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      //Mapper.Initialize(cfg =>  {cfg
        Mapper
        .CreateMap<Data.Entities.User, Models.User>()
        .ForMember(dest => dest.Links, opt => opt.Ignore());
      //});
    }
  }
}