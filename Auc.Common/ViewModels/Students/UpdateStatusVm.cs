using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Students
{
    public class UpdateStatusVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public int? StatusId { get; set; }
    }
}
