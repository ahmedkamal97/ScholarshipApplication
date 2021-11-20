using Auc.Common.ViewModels.University;
using Auc.Data.Interfaces;
using Auc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class UniversityService
    {
        private IUniversityRepo _repo;
        public UniversityService()
        {
            _repo = new UniversityRepo();
        }


        public IEnumerable<UniversityVM> GetUniversity()
        {
            return _repo.GetUniversity().
                Where(c => c.Removed == false)
                .Select(x => new UniversityVM
                {
                    Id=x.Id,
                    Name=x.Name
                });
        }
    }
}
