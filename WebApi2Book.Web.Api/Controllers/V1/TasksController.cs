using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi2Book.Web.Common.Routing;
using WebApi2Book.Web.Api.Models;
using WebApi2Book.Web.Api.MaintenanceProcessing;

using WebApi2Book.Web.Common;

namespace WebApi2Book.Web.Api.Controllers.V1
{
  //[ApiVersion1RoutePrefix("tasks")]
  [UnitOfWorkActionFilter]
  [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/tasks")]
  public class TasksController : ApiController
  {
    private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessing;

    [Route("{id:long}", Name = "GetTaskRoute")]
    public Task GetTask(long id)
    {
      return _addTaskMaintenanceProcessing.GetTask(id);
      /*
      return new Task
      {
        TaskId = id,
        Subject = "In v1 Task.Subject=Anna"
      };
      */
    }

    [Route("", Name ="AddTaskRoute")]
    [HttpPost]
    public Task AddTask(HttpRequestMessage requestMessage, NewTask newTask)
    {
      var task = _addTaskMaintenanceProcessing.AddTask(newTask);
      return task;

      /*
      return new Task
      {
        Subject = "In v1, new Task.Subject = " + newTask.Subject
      };
      */
    }

    public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessing)
    {
      _addTaskMaintenanceProcessing = addTaskMaintenanceProcessing;
    }
  }
}
