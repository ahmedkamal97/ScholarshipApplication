﻿using Auc.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auc.Data.DAL;

namespace Auc.Data.Repositories
{
    public class UserRepo: IusersRepo
    {
        private AUCDBEntities _db;
        public UserRepo()
        {
            _db = new AUCDBEntities();
        }
        public void Add(tblUser Entity)
        {
            _db.tblUsers.Add(Entity);
        }
        public IEnumerable<tblUser> GetUsers()
        {
            return _db.tblUsers;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

      
    }
}
