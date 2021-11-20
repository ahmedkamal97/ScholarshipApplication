using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auc.Data.DAL;
using Auc.Data.Interfaces;

namespace Auc.Data.Repositories
{
    public class UniversityRepo: IUniversityRepo
    {
        private AUCDBEntities _db;
        public UniversityRepo()
        {
            _db = new AUCDBEntities();
        }

        public IEnumerable<tblUniversity> GetUniversity()
        {
            return _db.tblUniversities;
        }
    }
}
