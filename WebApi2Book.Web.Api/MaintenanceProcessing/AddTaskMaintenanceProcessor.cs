using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
//using System.Threading.Tasks;

using WebApi2Book.Common;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Data.QueryProcessors;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.MaintenanceProcessing
{
  public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IAddTaskQueryProcessor _queryProcessor;

    public Task AddTask(NewTask newTask)
    {
      var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);
      _queryProcessor.AddTask(taskEntity);
      var task = _autoMapper.Map<Task>(taskEntity);

      //TODO: Implement link service
      task.AddLink(new Link {
        Method = HttpMethod.Get.Method,
        Href = "http://localhost:5000/api/v1/tasks" + task.TaskId,
        Rel = Constants.CommonLinkRelValues.Self
      });

      return task;
    }

    public Task GetTask(long taskId)
    {
      Data.Entities.Task task = _queryProcessor.GetTask(taskId);
      var peristedTask = _autoMapper.Map<Models.Task>(task);
      return peristedTask;
    }

    public AddTaskMaintenanceProcessor(IAutoMapper autoMapper, 
      IAddTaskQueryProcessor queryProcessor)
    {
      _autoMapper = autoMapper;
      _queryProcessor = queryProcessor;
    }
  }
}

