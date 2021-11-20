using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Dashboard
{
    public class DashboardContainerVM
    {
        public int PendingCount { get; set; }
        public int AceptedCount { get; set; }
        public int RejectedCount { get; set; }
    }
}
