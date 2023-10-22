using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CSharp.ModelValidators
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class CompareDateLessThanAttribute : ValidationAttribute
    {
        private readonly string _propToCompare;

        public CompareDateLessThanAttribute(string propToCompare)
        {
            _propToCompare = propToCompare;
        }
         
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value != null)
            {
                // Get value entered
                DateTime currentValue = (DateTime)value;
                // Get PropertyInfo for comparison property
                PropertyInfo pinfo = context.ObjectType.GetProperty(_propToCompare);
                // Ensure the comparison property
                // value is not null
                if (pinfo.GetValue(context.ObjectInstance) != null)
                {
                    // Get value for comparison property
                    DateTime comparisonValue = (DateTime)pinfo.GetValue(context.ObjectInstance);
                    // Perform the comparison
                    if (currentValue > comparisonValue)
                    {
                        return new ValidationResult(ErrorMessage, new[] { context.MemberName });
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
