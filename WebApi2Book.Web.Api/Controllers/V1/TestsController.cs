using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NHibernate;

using WebApi2Book.Common;
using WebApi2Book.Data.Entities;
using WebApi2Book.Data.QueryProcessors;
using WebApi2Book.Common.Security;

namespace WebApi2Book.Web.Api.Controllers.V1
{
  [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/tests")]
  public class TestsController : ApiController
  {
    private IDateTime _dt;
    private IAddTaskQueryProcessor _atqp;
    private ISession _session;
    private IUserSession _usession;
    [Route("{id:int:max(100)}")]
    public string GetTaskWithAMaxIdOf100(int id)
    {
      return "In GetTaskWithAMaxIdOf100(int id) method, id=" + id;
    }

    [Route("{id:int:min(101)}")]
    [HttpGet]
    public string FindTaskWithAMinIdOf101(int id)
    {
      return "In FindTaskWithAMinIdOf101(int id) method, id=" + id;
    }
    /*
        [Route("api/tasks/{id:int}")]
        public IHttpActionResult Get(long id)
        {
          return Ok($"TaskId={id};");
        }
    */
    //[Route("api/tasks/{tasknum:alpha}")]
    [Route("{msg}")]
    public string Get(string msg)
    {
      return $"Get msg={msg} at {_dt.UtcNow}";
    }

    //public TestsController(IDateTime dt, IAddTaskQueryProcessor atqp)
    public TestsController(IDateTime dt, ISession session, IUserSession usession)
    {
      _dt = dt;
      //_atqp = atqp;
      _session = session;
      _usession = usession;
    }
  }
}
