using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSharp.ModelValidators
{
    public static class ValidationHelper
    {
        public static List<ValidationErrorMessage> Validate<T>(T entity)
        {
            List<ValidationErrorMessage> ret = new List<ValidationErrorMessage>();

            // Create instance of ValidationContext object
            ValidationContext context = new ValidationContext(entity, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                // Get validation results
                foreach (ValidationResult item in results)
                {
                    string propName = string.Empty;
                    if (item.MemberNames.Any())
                    {
                        propName = ((string[])item.MemberNames)[0];
                    }
                    // Build new ValidationMessage object
                    ValidationErrorMessage msg = new ValidationErrorMessage()
                    {
                        Message = item.ErrorMessage,
                        PropertyName = propName
                    };

                    // Add validation object to list
                    ret.Add(msg);
                }
            }

            return ret;
        }
    }
}
