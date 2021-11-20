using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Students
{
    public class StudentFilter
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public int? University { get; set; }
        public int? StatusId { get; set; }
    }
}
