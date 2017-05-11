using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Util;
using WebApi2Book.Common;
using WebApi2Book.Common.Security;
using WebApi2Book.Data;
using WABE = WebApi2Book.Data.Entities;
using WebApi2Book.Data.Exceptions;
using WebApi2Book.Data.QueryProcessors;

namespace WebApi2Book.Data.SqlServer.QueryProcessors
{
  public class AddTaskQueryProcessor : IAddTaskQueryProcessor
  {
    private readonly IDateTime _dateTime;
    private readonly ISession _session;
    private readonly IUserSession _userSession;

    public void AddTask(WABE.Task task)
    {
      task.CreatedDate = _dateTime.UtcNow;
      task.Status = _session.QueryOver<WABE.Status>().Where(
        x => x.Name == "Not Started").SingleOrDefault();

      //task.CreatedBy = _session.QueryOver<WABE.User>().Where(
      //  x => x.Username == _userSession.Username).SingleOrDefault();
      // TODO: Just a hack
      task.CreatedBy = _session.Get<WABE.User>(1L);

      if (task.Users != null && task.Users.Any())
      {
        for (var i = 0; i < task.Users.Count; i++)
        {
          var user = task.Users[i];
          var persistedUser = _session.Get<WABE.User>(user.UserId);
          if(persistedUser == null)
          {
            throw new ChildObjectNotFoundException($"User with id{user.UserId} not found");
          }
          task.Users[i] = persistedUser;
        }
      }
      _session.SaveOrUpdate(task);
    }

    public WABE.Task GetTask(long taskId)
    {
      var task = _session.QueryOver<WABE.Task>().Where(
        x => x.TaskId == taskId).SingleOrDefault();
      if ( task == null)
      {
        throw new ChildObjectNotFoundException($"Task {taskId} not found");
      }
      return task;
    }

    public AddTaskQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
    {
      _dateTime = dateTime;
      _session = session;
      _userSession = userSession;
    }
  }
}

