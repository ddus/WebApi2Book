using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi2Book.Web.Common.Routing;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.Controllers
{
  [ApiVersion1RoutePrefix("categories")]
  public class CategoriesController : ApiController
  {
    public IHttpActionResult Post(HttpRequestMessage request, Category category)
    {
      return NotFound();
    }
  }
}
