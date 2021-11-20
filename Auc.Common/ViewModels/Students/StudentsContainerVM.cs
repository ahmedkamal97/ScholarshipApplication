using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Students
{
    public class StudentsContainerVM
    {
        public IEnumerable<StudentVM> Student { get; set; }
        public StudentFilter Filter { get; set; }
    }
}
