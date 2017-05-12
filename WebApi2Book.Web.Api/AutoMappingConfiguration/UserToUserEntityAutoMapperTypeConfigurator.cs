﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;
using WebApi2Book.Web.Common;
using User = WebApi2Book.Web.Api.Models.User;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class UserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator, IAutoMapperTypeConfigurator2
  {
    public void Configure()
    {
      Mapper.CreateMap<User, Data.Entities.User>()
        .ForMember(opt => opt.Version, x => x.Ignore());
    }

    public void Configure(IConfiguration cfg)
    {
      cfg.CreateMap<User, Data.Entities.User>()
        .ForMember(opt => opt.Version, x => x.Ignore());
    }
  }
}
