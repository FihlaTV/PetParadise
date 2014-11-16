namespace PetParadise.Data.Models.Validators
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime val = (DateTime)value;

            if (val >= DateTime.Now || val <= DateTime.Now.AddYears(2))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(this.ErrorMessageString);
            }
        }
    }
}
