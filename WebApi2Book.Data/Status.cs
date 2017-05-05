using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch3_WebApi2Book.Web.Api.Models
{
  public class Status
  {
    public virtual long StatusId { get; set; }
    public virtual string Name { get; set; }
    public virtual int Ordinal { get; set; }
    public virtual byte[] Version { get; set; }
  }
}
