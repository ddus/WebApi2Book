using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.Entities;
using WebApi2Book.Web.Common;
//using User = WebApi2Book.Web.Api.Models.User;

namespace WebApi2Book.Web.Api.AutoMappingConfiguration
{
  public class TaskAssigneesResolver : ValueResolver<Task, List<Models.User>>
  {
    public IAutoMapper AutoMapper
    {
      get { return WebContainerManager.Get<IAutoMapper>(); }
    }

    protected override List<Models.User> ResolveCore(Task source)
    {
      return source.Users.Select((Data.Entities.User x) => AutoMapper.Map<Models.User>(x)).ToList();
    }
  }
}