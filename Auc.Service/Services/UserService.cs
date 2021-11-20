using Auc.Common.ViewModels.Users;
using Auc.Data.DAL;
using Auc.Data.Interfaces;
using Auc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class UserService
    {
        private IusersRepo _repo;
        public UserService()
        {
            _repo = new UserRepo();
        }

        public IEnumerable<UsersVM> GetUsers()
        {
            return _repo.GetUsers()
                .Where(c => c.Removed == false)
                .Select(x => new UsersVM
                {
                    Id = x.Id,
                    EmailAddress = x.EmailAddress,
                    PassWord = x.Password,
                    UserType=x.UserType
                });
        }


        public void AddUser(AddUserVM Entity)
        {
            var User = new tblUser
            {
                EmailAddress = Entity.EmailAddress,
                Password = Entity.PassWord,
                Removed = false,
                UserType=StaticUsersType.Student
            };
            _repo.Add(User);
            _repo.Save();
        }


        public UsersVM GatUserFromMail(string EmailAddress)
        {
            var User = GetUsers().FirstOrDefault(c => c.EmailAddress?.ToLower() == EmailAddress?.ToLower());
            if (User != null)
                return User;
            else
                return new UsersVM();
        }


        public string CheckPassWord(string Password,int UserId)
        {
            var _password = GetUsers().FirstOrDefault(c => c.Id == UserId).PassWord;
            if (Password == _password)
                return null;
            else
                return "PassWord";

        }
    }
}
