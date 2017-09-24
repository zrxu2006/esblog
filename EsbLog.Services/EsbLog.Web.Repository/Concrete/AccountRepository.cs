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

        public int ValidateUser(string username, string password)
        {
            MD5 md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            var md5String = Convert.ToBase64String(bytes);
            int userId;
            using (var context = _factory.GetPlatformDb())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.LoginName == username
                            && u.Password == md5String
                            && u.UserType == "M");
                userId = user==null?0:user.Id;                
            }

            return userId;
        }


        public void UpdateLoginTime(int userId)
        {
            using (var context = _factory.GetPlatformDb())
            {
                var user = context.Users
                            .FirstOrDefault(u=>u.Id==userId);
                if (user != null)
                {
                    user.LoginTime = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}
