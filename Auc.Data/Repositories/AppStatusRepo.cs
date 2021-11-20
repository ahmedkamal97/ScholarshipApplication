using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auc.Data.DAL;
using Auc.Data.Interfaces;

namespace Auc.Data.Repositories
{
    public class AppStatusRepo: IAppStatusRepo
    {
        private AUCDBEntities _db;
        public AppStatusRepo()
        {
            _db = new AUCDBEntities();
        }

        public IEnumerable<tblAppStatu> GetAppStatus()
        {
            return _db.tblAppStatus;
        }
    }
}
