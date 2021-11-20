using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auc.Data.DAL;

namespace Auc.Data.Interfaces
{
    public interface IAppStatusRepo
    {
        IEnumerable<tblAppStatu> GetAppStatus();
    }
}
