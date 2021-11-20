using Auc.Common.ViewModels.Students;
using Auc.Data.Interfaces;
using Auc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class AppStatusService
    {
        private IAppStatusRepo _repo;
        public AppStatusService()
        {
            _repo = new AppStatusRepo();
        }


        public IEnumerable<AppStatusVM> GetAppStatuses()
        {
            return _repo.GetAppStatus()
                .Select(x => new AppStatusVM
                {
                    Id=x.Id,
                    Name=x.ApplicationStatus
                });
        }
    }
}
