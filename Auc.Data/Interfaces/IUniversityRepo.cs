using Auc.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Data.Interfaces
{
    public interface IUniversityRepo
    {
        IEnumerable<tblUniversity> GetUniversity();
    }
}
