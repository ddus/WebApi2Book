using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApi2Book.Data.Entities;

namespace WebApi2Book.Data.SqlServer.Mapping
{
  public class TestMap : VersionedClassMap<Test>
  {
    public TestMap()
    {
      Id(x => x.TestId);
      Map(x => x.Subject).Not.Nullable();
      Map(x => x.CreatedDate).Not.Nullable();
      References(x => x.TestStatus, "StatusId");
    }
  }
}
