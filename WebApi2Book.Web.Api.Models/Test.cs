using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Web.Api.Models
{
  public class Test
  {
    public long? TestId { get; set; }
    public string Subject { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Status TestStatus { get; set; }
  }
}
