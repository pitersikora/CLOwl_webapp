using ClowlWebApp.Interfaces;
using ClowlWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClowlWebApp.Validators
{
    public class PasswordSubstring : ValidationAttribute
    {

        public string GetErrorMessage() => $"Password cannot contain your name or surname.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (RegistrationModel)validationContext.ObjectInstance;

            if (model.Password.ToUpper().Contains(model.FirstName.ToUpper()) || model.Password.ToUpper().Contains(model.LastName.ToUpper()))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
