﻿using EsbLog.Platform.Database;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EsbLog.Web.Repository
{
    public interface IAccountRepository
    {
        bool ValidateUser(string username, string password);
    }
       
}
