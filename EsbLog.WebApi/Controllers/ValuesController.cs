using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EsbLog.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        IPlatformDbContext _db;
        //public ValuesController(IPlatformDbContext db)
        //{
        //    _db = db;
        //}

        // GET api/values
        public IEnumerable<string> Get()
        {

            log4net.LogManager.GetLogger("EsbLog.App.Log").Info("values get");
            return new string[] { "value1", "value2" };

        }

        //public IEnumerable<string> GetAllValues()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
