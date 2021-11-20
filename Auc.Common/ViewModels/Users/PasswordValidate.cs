using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auc.Common.ViewModels.Users
{
    public class PasswordValidate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var User = (AddUserVM)validationContext.ObjectInstance;
            if (User.PassWord != User.RePassWord)
                return new ValidationResult("Password Not Matching ! ");
            else
                return ValidationResult.Success;
        }
    }
}
