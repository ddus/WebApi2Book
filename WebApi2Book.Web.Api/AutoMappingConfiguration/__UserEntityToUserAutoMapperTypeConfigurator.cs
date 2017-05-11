using AutoMapper;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      Mapper.CreateMap<Data.Entities.User, Models.User>()
            .ForMember(opt => opt.Links, x => x.Ignore());

        /*
              Mapper.Initialize(cfg =>
              {
                cfg.CreateMap<Data.Entities.User, Models.User>()
                    .ForMember(opt => opt.Links, x => x.Ignore());
              });
        */
      }
  }
}