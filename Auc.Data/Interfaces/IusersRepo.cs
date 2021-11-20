using Auc.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Data.Interfaces
{
    public interface IusersRepo
    {
        IEnumerable<tblUser> GetUsers();
        void Add(tblUser Entity);
        void Save();
    }
}
