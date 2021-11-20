using Auc.Common.ViewModels.Dashboard;
using Auc.Common.ViewModels.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Service.Services
{
    public class DashboardService
    {
        private StudentService _studentService;
        public DashboardService()
        {
            _studentService = new StudentService();
        }

        public DashboardContainerVM GetCounts()
        {
            var Students = _studentService.GetStudents();
            var ViewModel = new DashboardContainerVM
            {
                PendingCount=Students.Where(c=>c.StatusId==StaticAppStatus.Pending).Count(),
                AceptedCount=Students.Where(c=>c.StatusId==StaticAppStatus.Accepted).Count(),
                RejectedCount=Students.Where(c=>c.StatusId==StaticAppStatus.Rejected).Count()
            };
            return ViewModel;
        }
    }
}
