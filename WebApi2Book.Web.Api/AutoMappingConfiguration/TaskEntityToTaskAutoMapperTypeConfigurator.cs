using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      //Mapper.Initialize(cfg =>  {cfg
        Mapper
        .CreateMap<Data.Entities.Task, Models.Task>()
          .ForMember(opt => opt.Links, x => x.Ignore())
          .ForMember(opt => opt.Assignees,
              x => x.ResolveUsing<TaskAssigneesResolver>());
      //});
    }
  }
}