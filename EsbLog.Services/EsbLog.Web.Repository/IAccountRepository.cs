using EsbLog.Platform.Database;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EsbLog.Domain.Platform;

namespace EsbLog.Web.Repository
{
    public interface IAccountRepository
    {
        bool AddUser(LoginUser user);
        int ValidateUser(string username, string password);

        void UpdateLoginTime(int userId);

        IEnumerable<LoginUser> FindUsers();

        bool BindUserApp(int userId,IEnumerable<int> appIdList);
    }
       
}
