using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EsbLog.Api.Controllers
{
    public class ValuesController : ApiController
    {
        IPlatformDbContext _db;
        public ValuesController(IPlatformDbContext db)
        {
            _db = db;
        }
        public IHttpActionResult Get(int id)
        {
            int c = _db.Apps.Count();
            return this.Ok(string.Format("id:{0}", id));
        }
    }
}
