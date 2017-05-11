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
  public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
  {
    public void Configure()
    {
      Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<Data.Entities.User, User>()
        .ForMember(opt => opt.Links, x => x.Ignore());
      });
    }
  }
}