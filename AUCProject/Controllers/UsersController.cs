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
            var UserId = _userService.GatUserFromMail(Entity.EmailAddress);
            if (UserId != 0 && _studentService.CheckExsistApp(UserId))
            {
                if (_userService.CheckPassWord(Entity.PassWord, UserId) == null)
                    return RedirectToAction("EditStudentApp", "Students", new { UserId = UserId });
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
          
            
            _userService.AddUser(Entity);
            return RedirectToAction("NewApp", "Students");
        }
    }
}