﻿using EsbLog.Platform.Database;
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
        LoginUser FindUserById(int userId);

        bool EditUser(LoginUser user);

        void UpdatePsw(int userId, string newPsw);
        int GetCount();
    }
       
}
