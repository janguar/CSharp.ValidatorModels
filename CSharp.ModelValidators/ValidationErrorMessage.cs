using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.ModelValidators
{
    public class ValidationErrorMessage
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(PropertyName))
            {
                return $"{Message}";
            }
            else
            {
                return $"{Message} ({PropertyName})";
            }
        }
    }
}
