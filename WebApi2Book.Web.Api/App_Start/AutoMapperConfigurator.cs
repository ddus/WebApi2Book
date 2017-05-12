using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using WebApi2Book.Common.TypeMapping;

namespace WebApi2Book.Web.Api
{
  public class AutoMapperConfigurator
  {
    public void Configure(
      IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations,
      IEnumerable<IAutoMapperTypeConfigurator2> autoMapperTypeConfigurations2)
    {
      if (autoMapperTypeConfigurations2 != null)
      {
        Mapper.Initialize(cfg =>
        {
          autoMapperTypeConfigurations2.ToList().ForEach(x => x.Configure(cfg));
        });
      }
      if (autoMapperTypeConfigurations != null)
      {
        autoMapperTypeConfigurations.ToList().ForEach(x => x.Configure());
      }
      Mapper.AssertConfigurationIsValid();
    }
  }
}