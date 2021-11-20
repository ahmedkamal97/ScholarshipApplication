using Auc.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Data.Interfaces
{
    public interface IStudentsRepo
    {
        IEnumerable<tblStudent> GetStudents();
        void Add(tblStudent Entity);
        void Update(tblStudent Entity);

        void UpdateStatus(int? StatusId,int StudentId);
        void Save();
    }
}
