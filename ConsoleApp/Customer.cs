using CSharp.ModelValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Customer
    {
        [CustomValidation(typeof(WeekdayOnlyValidator),
            nameof(WeekdayOnlyValidator.Validate),
            ErrorMessage = "The Entered Date Must Not Fall on a Weekend.")]
        public DateTime EntryDate { get; set; }
    }
}
