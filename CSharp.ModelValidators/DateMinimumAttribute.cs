using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharp.ModelValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DateMinimumAttribute : ValidationAttribute
    {
        public DateMinimumAttribute(string minDate)
        {
            _minDate = Convert.ToDateTime(minDate);
        }

        private readonly DateTime _minDate;

        protected override ValidationResult IsValid(object value, ValidationContext vc)
        {
            if (value != null)
            {
                // Get the value entered
                DateTime dateEntered = (DateTime)value;

                // Get the display name for validation message
                string displayName = vc.DisplayName;

                // See if the date entered is less than
                // or equal to the minimum date set
                if (dateEntered <= _minDate)
                {
                    // Check if ErrorMessage is filled in
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        ErrorMessage = $"{displayName} must be greater than or equal to '{_minDate:MM/dd/yyyy}'.";
                    }

                    return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
