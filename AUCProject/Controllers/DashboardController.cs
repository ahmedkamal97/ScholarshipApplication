using Auc.Common.ViewModels.Dashboard;
using Auc.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCProject.Controllers
{
    public class DashboardController : Controller
    {


        private DashboardService _dashboardService;
        public DashboardController()
        {
            _dashboardService = new DashboardService();
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            var Counts = _dashboardService.GetCounts();
            var ViewModel = new DashboardContainerVM
            {
                PendingCount = Counts.PendingCount,
                AceptedCount = Counts.AceptedCount,
                RejectedCount =Counts.RejectedCount
            };
            return View(ViewModel);
        }
    }
}