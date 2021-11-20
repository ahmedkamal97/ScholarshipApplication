using Auc.Common.ViewModels.Users;
using Auc.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCProject.Controllers
{
    public class UsersController : Controller
    {
        private UserService _userService;
        private StudentService _studentService;
        public UsersController()
        {
            _userService = new UserService();
            _studentService = new StudentService();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AddUserVM Entity)
        {

            var User = _userService.GatUserFromMail(Entity.EmailAddress);

            if (User != null && User.UserType == StaticUsersType.Student)
            {
                if (_studentService.CheckExsistApp(User.Id))
                {
                    if (_userService.CheckPassWord(Entity.PassWord, User.Id) == null)
                    {
                        if (!ModelState.IsValid)
                            return View(Entity);
                        return RedirectToAction("EditStudentApp", "Students", new { UserId = User.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password is InnCorrect");
                        return View(Entity);
                    }
                }

                else
                {
                    if (!ModelState.IsValid)
                        return View(Entity);
                }



            }

            else if (User != null && User.UserType == StaticUsersType.Admin)

            {
                if (_userService.CheckPassWord(Entity.PassWord, User.Id) == null)
                    return RedirectToAction("Index", "Students");
                else
                {
                    ModelState.AddModelError("Password", "Password is InnCorrect");
                    return View(Entity);
                }


            }

            else
            
                _userService.AddUser(Entity);
                var MaxId = _userService.GetMaxId();
                return RedirectToAction("NewApp", "Students", new { UserId = MaxId });
            



        }
    }
}