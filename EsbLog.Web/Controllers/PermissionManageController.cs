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
                                .Where(u => string.IsNullOrEmpty(queryRequest.UserName)
                                        || u.LoginName.Contains(queryRequest.UserName));

            return View(apploginUsers);
        }

        public ActionResult Add()
        {
            var applist = _appRepo.FindAllApps();
            //.Where(a => a.Users == null);
            LoginUserEditModel model = new LoginUserEditModel
            {
                AppList = applist
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LoginUserEditModel addModel)
        {
            var loginUser = Mapper.Map<LoginUser>(addModel);
            bool success = _accountRepo.AddUser(loginUser);
            addModel.Id = loginUser.Id;
            TempData["success"] = success;
            return RedirectToAction("Edit", new { id = addModel.Id });
        }

        public ActionResult Edit(int id)
        {
            var user = _accountRepo.FindUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var loginUser = Mapper.Map<LoginUserEditModel>(user);
            loginUser.AppList = _appRepo.FindAllApps();
            return View("Add", loginUser);
        }

        [HttpPost]
        public ActionResult Edit(LoginUserEditModel user)
        {
            var loginUser = Mapper.Map<LoginUser>(user);
            bool success = _accountRepo.EditUser(loginUser);

            TempData["success"] = success;
            return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}