using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Auc.Common.ViewModels.Students
{
    public class StudentVM
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public string BirthDataStr { get; set; }

        [Required]
        [Display(Name = "National Id")]
        public string NationalId { get; set; }

        [Required]
        public int? UniversityId { get; set; }

        public string UniversityName { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public double? GPA { get; set; }

        [Required]
        public HttpPostedFileBase Resume { get; set; }
        public string ResumePath { get; set; }

        public int? StatusId { get; set; }
        public string Status { get; set; }
    }
}
