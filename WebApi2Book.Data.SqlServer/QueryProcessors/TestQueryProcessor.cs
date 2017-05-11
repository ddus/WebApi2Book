using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

using WebApi2Book.Common;
using WebApi2Book.Common.Security;
using WebApi2Book.Data.Entities;
using WebApi2Book.Data.QueryProcessors;

namespace WebApi2Book.Data.SqlServer.QueryProcessors
{
  public class TestQueryProcessor : ITestQueryProcessor
  {
    ISession _session;
    IUserSession _userSession;
    IDateTime _dateTime;
    public void AddTest(Test test)
    {
      throw new NotImplementedException();
    }

    public Test GetTest(long id)
    {
      throw new NotImplementedException();
    }

    public TestQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
    {
      _session = session;
      _userSession = userSession;
      _dateTime = dateTime;
    }
  }
}
