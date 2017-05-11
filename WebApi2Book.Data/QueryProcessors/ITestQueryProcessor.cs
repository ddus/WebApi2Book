using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebApi2Book.Data.Entities;

namespace WebApi2Book.Data.QueryProcessors
{
  public interface ITestQueryProcessor
  {
    void AddTest(Test test);
    Test GetTest(long id);
  }
}
