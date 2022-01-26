using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkExample.CustomValidations
{
    public class DivideBy10ValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           Double price=Convert.ToDouble(value);
            if (price % 10 == 0)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult(this.ErrorMessage);
        }
    }
}