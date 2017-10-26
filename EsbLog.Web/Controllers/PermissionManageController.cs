using AutoMapper;
using EsbLog.Domain.Platform;
using EsbLog.Web.Infrastructure;
using EsbLog.Web.Models;
using EsbLog.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsbLog.Web.Controllers
{
    [EsblogAuth]
    public class PermissionManageController : Controller
    {
        IAppManagerRepository _appRepo;
        IPermissionRepository _perRepo;
        IAccountRepository _accountRepo;
        public PermissionManageController(IAppManagerRepository appRepository,
                IAccountRepository accountRepo)
        {
            _appRepo = appRepository;
            _accountRepo = accountRepo;
        }

        // GET: /Permission/
        public ActionResult Index()
        {
            var appLoginUsers = _accountRepo.FindUsers();

            return View(appLoginUsers);
        }

        [HttpPost]
        public ActionResult Index(PermissionQueryRequest queryRequest)
        {
            var apploginUsers = _accountRepo.FindUsers()
                                .Where(u=> string.IsNullOrEmpty(queryRequest.UserName)
                                        || u.LoginName.Contains(queryRequest.UserName));

            return View(apploginUsers);
        }

        public ActionResult Add()
        {
            var applist = _appRepo.FindAllApps()
                            .Where(a => a.Users == null);
            LoginUserAddModel model = new LoginUserAddModel
            {
                AppList = applist
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LoginUserAddModel addModel)
        {
            //Mapper.Initialize(c => c.AddProfile<EsbLogAutoMapperProfile>());
            var loginUser = Mapper.Map<LoginUser>(addModel);
            _accountRepo.AddUser(loginUser);
            return null;

            //return View(model);
        }
	}
}