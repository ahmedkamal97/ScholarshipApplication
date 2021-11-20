using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Users
{
    public class AddUserVM
    {
        [Required]
        [Display(Name ="Email Address")]
        public  string EmailAddress { get; set; }

        [Required]
        [Display(Name ="Password")]
        [PasswordValidate]
        public string PassWord { get; set; }

        [Required]
        [PasswordValidate]
        public string RePassWord { get; set; }
    }
}
