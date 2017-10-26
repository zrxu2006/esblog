using EsbLog.Domain.Platform;
using EsbLog.Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
               
        public IEnumerable<LoginUser> FindUsers()
        {
            using (var context = _factory.GetPlatformDb())
            {
                var users = context.Users
                            .Include(u=>u.Apps)
                            .Where(u => u.UserType=="U")
                            .ToList();
                return users;
            }
        }

        public bool BindUserApp(int userId, IEnumerable<int> appIdList)
        {
            return true;
        }

        public bool AddUser(LoginUser user)
        {
            using (var context = _factory.GetPlatformDb())
            {
                var appIds = user.Apps.Select(a => a.AppId)
                                .ToList();
                var apps = context.Apps.Where(a => appIds.Contains(a.AppId))
                            .ToList();
                user.Apps = apps;
                context.Users.Add(user);
                context.SaveChanges();
            }

            return true;
        }
    }
}
