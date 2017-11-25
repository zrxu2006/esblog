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
            var md5String = GetMd5String(password);
            int userId;
            using (var context = _factory.GetPlatformDb())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.LoginName.Equals(username, StringComparison.Ordinal)
                            && u.Password == md5String);
                            //&& u.UserType == "M");
                userId = user==null?0:user.Id;                
            }

            return userId;
        }

        private string GetMd5String(string str)
        {
            MD5 md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return Convert.ToBase64String(bytes);
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


        public LoginUser FindUserById(int userId)
        {
            using (var context = _factory.GetPlatformDb())
            {
                var user = context.Users
                            .Include(u => u.Apps)
                            .Where(u=> u.Id == userId)
                            .FirstOrDefault();
                return user;

            }
        }


        public bool EditUser(LoginUser user)
        {
            using (var context = _factory.GetPlatformDb())
            {
                var appIds = user.Apps.Select(a => a.AppId)
                                .ToList();
                var apps = context.Apps.Where(a => appIds.Contains(a.AppId))
                            .ToList();

                var updatingUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
                if (updatingUser == null)
                {
                    return false;
                }

                updatingUser.LoginName = user.LoginName;
                updatingUser.Apps = apps;
                context.SaveChanges();
            }

            return true;
        }


        public int GetCount()
        {
            using (var context = _factory.GetPlatformDb())
            {
                return context.Users.AsNoTracking()
                    .Where(u=> u.UserType=="U")
                    .Count();
            }
        }
        
        public void UpdatePsw(int userId, string newPsw)
        {
            using (var db = _factory.GetPlatformDb())
            {
                var user = db.Users                           
                            .Where(u => u.Id == userId)
                            .FirstOrDefault();

                if(user!=null)
                {
                    user.Password = GetMd5String(newPsw);
                    db.SaveChanges();
                }
            }
        }
    }
}
