using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbLog.Domain.Log;
using System.Reflection;

namespace EsbLog.Platform.Database.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var type = typeof(LogLevel);
            var members = type.GetMembers(BindingFlags.GetProperty);
            foreach (var member in members)
            {
                
            }
        }
    }
}
