namespace ConsoleApp
{
    public class Employee: IValidatableObject
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Range(1.00, 9999)]
        public decimal? Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }



        /// <summary>
        /// Implement Validate() method for  the IValidateObject interface
        /// </summary>
        /// <param name="validationContext">
        ///   An instance of the ValidationContext
        /// </param>
        /// <returns>
        ///   A collection of ValidationResult objects
        /// </returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> ret = new List<ValidationResult>();

            if (FirstName.Length < 2)
            {
                ret.Add(new ValidationResult("First Name must have at least 2 characters.", new[] { nameof(FirstName) }));
            }
            if (LastName.Length < 3)
            {
                ret.Add(new ValidationResult("Last Name must have at least 3 characters.", new[] { nameof(LastName) }));
            }
            if (Salary < 1)
            {
                ret.Add(new ValidationResult("Salary must be greater than $1.00.", new[] { nameof(Salary) }));
            }
            string minStartDate = DateTime.Now.AddDays(-7).ToString("D");
            if (StartDate < DateTime.Parse(minStartDate))
            {
                ret.Add(new ValidationResult($"Start Date must be later than {minStartDate}.", new[] { nameof(StartDate) }));
            }
            if (TerminationDate.HasValue && TerminationDate < StartDate)
            {
                ret.Add(new ValidationResult($"Termination Date must be later than {StartDate}.", new[] { nameof(TerminationDate) }));
            }

            return ret;

        }
    }
}
