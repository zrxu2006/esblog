using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EsbLog.WebApi.Tests.Repository
{
    [TestClass]
    public class LogRepositoryTest
    {
        [TestMethod]
        public void Add()
        {

            save();
        }

        private void save()
        {
            //ILogRepository r = new EFLogRepository();

            //List<Task<int>> tlist = new List<Task<int>>();
            //for (int i = 0; i < 5000; i++)
            //{
            //    Log l = new Log();
            //    l.AppId = 1123;
            //    l.Ticks = DateTime.Now.Ticks;
            //    //r.Save(l);
            //    tlist.Add(r.SaveAsync(l));
            //}

            //Task.WaitAll(tlist.ToArray());
        }
    }
}
