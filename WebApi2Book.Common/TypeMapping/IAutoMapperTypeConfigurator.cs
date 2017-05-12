using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace WebApi2Book.Common.TypeMapping
{
  public interface IAutoMapperTypeConfigurator
  {
    void Configure();
  }

  public interface IAutoMapperTypeConfigurator2
  {
    void Configure(IConfiguration cfg);
  }
}
