using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CSharp.ModelValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CompareDecimalLessThanAttribute: ValidationAttribute
    {
        private readonly string _propToCompare;

        public CompareDecimalLessThanAttribute(string propToCompare)
        {
            _propToCompare = propToCompare;
        }


        protected override ValidationResult IsValid(object value, ValidationContext vc)
        {
            if (value != null)
            {
                // Get value entered
                decimal currentValue = (decimal)value;
                // Get PropertyInfo for comparison property
                PropertyInfo pinfo = vc.ObjectType.GetProperty(_propToCompare);
                // Ensure the comparison property
                // value is not null
                if (pinfo.GetValue(vc.ObjectInstance) != null)
                {
                    // Get value for comparison property
                    decimal comparisonValue = (decimal)pinfo.GetValue(vc.ObjectInstance);
                    // Perform the comparison
                    if (currentValue > comparisonValue)
                    {
                        return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}
