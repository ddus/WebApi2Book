using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2Book.Data.Entities
{
  public class Test : IVersionedEntity
  {
    public virtual long? TestId { get; set; }
    public virtual string Subject { get; set; }
    public virtual Status TestStatus { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual byte[] Version { get; set; }
  }
}
