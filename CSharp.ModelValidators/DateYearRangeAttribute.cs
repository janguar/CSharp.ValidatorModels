using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharp.ModelValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class DateYearRangeAttribute : ValidationAttribute
    {
        public DateYearRangeAttribute(int yearsPrior, int yearsAfter)
        {
            _minDate = DateTime.Now.AddYears(yearsPrior);
            _maxDate = DateTime.Now.AddYears(yearsAfter);
        }

        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        protected override ValidationResult IsValid(object value, ValidationContext vc)
        {
            if (value != null)
            {
                // Get the value entered
                var dateEntered = (DateTime)value;

                // Get display name for validation message
                string displayName = vc.DisplayName;

                // See if the date entered is within the date range
                if (dateEntered < _minDate || dateEntered > _maxDate)
                {
                    // Check if ErrorMessage is filled in
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        ErrorMessage = $"{displayName} must be between '{_minDate:MM/dd/yyyy}' and '{_maxDate:MM/dd/yyyy}'.";
                    }

                    return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }

}
