using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi2Book.Web.Common.Routing;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.Controllers.V2
{
  //[ApiVersion1RoutePrefix("tasks")]
  [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
  public class TasksController : ApiController
  {
    [Route("{id:long}", Name = "GetTaskRoute2")]
    public Task Get(HttpRequestMessage requestMessage, long id)
    {
      return new Task
      {
        TaskId = id,
        Subject = "In v2 Task.Subject=Anna"
      };
    }

    [Route("", Name = "AddTaskRoute2")]
    [HttpPost]
    public Task AddTask(HttpRequestMessage requestMessage, NewTaskV2 newTask)
    {
      return new Task
      {
        Subject = "In v2, new Task.Subject = " + newTask.Subject
      };
    }
  }
}
