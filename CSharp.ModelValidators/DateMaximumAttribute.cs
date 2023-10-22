using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharp.ModelValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    // TODO: culture date time
    public class DateMaximumAttribute : ValidationAttribute
    {

        private readonly DateTime _maxDate;

        public DateMaximumAttribute(string maxDate)
        {
            DateTime.TryParse(maxDate, out _maxDate);

            //_maxDate = Convert.ToDateTime(maxDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext vc)
        {
            if (value != null)
            {
                // Get the value entered
                DateTime dateEntered = (DateTime)value;

                // Get display name for validation message
                string displayName = vc.DisplayName;

                // See if the date entered is greater than
                // or equal to the maximum date set
                if (dateEntered >= _maxDate)
                {
                    // Check if ErrorMessage is filled in
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        ErrorMessage = $"{displayName} must be less than or equal to '{_maxDate:MM/dd/yyyy}'.";
                    }

                    return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
