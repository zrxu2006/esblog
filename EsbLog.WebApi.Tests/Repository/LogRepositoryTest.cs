using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Domain;

namespace EsbLog.WebApi.Tests.Repository
{
    [TestClass]
    public class LogRepositoryTest
    {
        [TestMethod]
        public void Add()
        {
            ILogRepository r = new EFLogRepository();

            

            for (int i = 0; i < 50; i++)
            {
                Log l = new Log();
                l.AppId = i;
                r.SaveAsync(l);
            }

        }
    }
}
