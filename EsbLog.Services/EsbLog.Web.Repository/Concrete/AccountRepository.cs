using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        PlatformDbFactory _factory;
        public AccountRepository(PlatformDbFactory dbFactory)
        {
            _factory = dbFactory;
        }

        public bool ValidateUser(string username, string password)
        {
            MD5 md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            var md5String = Convert.ToBase64String(bytes);

            //using (DbContext context = _factory.GetPlatformDb())
            //{
            //    //context.Users
            //}
            return true;
        }
    }
}
