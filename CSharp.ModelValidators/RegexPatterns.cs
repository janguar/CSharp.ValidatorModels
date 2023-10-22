using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.ModelValidators
{
    public static class RegexPatterns
    {
        /// <summary>
        /// Regex for email validations
        /// </summary>
        public static string EmailValidatorPattern { get; } = "^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$";
    }
}
