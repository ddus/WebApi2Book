using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Task = WebApi2Book.Web.Api.Models.Task;

namespace WebApi2Book.Web.Api.MaintenanceProcessing
{
  public class TaskCreatedActionResult : IHttpActionResult
  {
    private readonly Models.Task _createdTask;
    private readonly HttpRequestMessage _requestMessage;

    public HttpResponseMessage Execute()
    {
      var responseMessage = _requestMessage.CreateResponse(
        HttpStatusCode.Created, _createdTask);
      return responseMessage;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
      return System.Threading.Tasks.Task.FromResult(Execute());
    }

    public TaskCreatedActionResult(HttpRequestMessage requestMessage, Models.Task createdTask)
    {
      _createdTask = createdTask;
      _requestMessage = requestMessage;
    }
  }
}