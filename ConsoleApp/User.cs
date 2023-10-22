using ConsoleApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class User
    {
        public int UserId { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(ValidationMessages.Required), 
            ErrorMessageResourceType = typeof(ValidationMessages))]
        public string LoginId { get; set; }

        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        //[RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$",
        //    ErrorMessage = "The email address entered is not valid.")]

        //[EmailAddress()]
        [EmailAddress(
            ErrorMessageResourceName = nameof(ValidationMessages.Email), 
            ErrorMessageResourceType = typeof(ValidationMessages))]
        public string EmailAddress { get; set; }



        [Phone(
            ErrorMessageResourceName = nameof(ValidationMessages.Phone), 
            ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Phone { get; set; }


    }
}
