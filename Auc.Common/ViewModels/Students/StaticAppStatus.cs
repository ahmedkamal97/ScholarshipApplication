using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Students
{
    public static class StaticAppStatus
    {
        public static int? Pending { get { return 1; } }
        public static int? Accepted { get { return 2; } }
        public static int? Rejected { get { return 3; } }
    }
}
