using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAB = WebApi2Book.Data.Entities;

namespace WebApi2Book.Data.QueryProcessors
{
  public interface IAddTaskQueryProcessor
  {
    void AddTask(WAB.Task task);

    WAB.Task GetTask(long taskId);
  }
}
