using System;
using UserSignup.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace UserSignup.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "A username is required")]

        [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 15 characters")]

        [RegularExpression(@"[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string Username { get; set; }



        [EmailAddress(ErrorMessage = "Sorry, that is not a valid email")]

        public string Email { get; set; }



        [Required(ErrorMessage = "A password is required")]

        [StringLength(30, MinimumLength = 6)]

        public string Password { get; set; }



        [Display(Name = "Verify Password")]

        [Compare("Password", ErrorMessage = "Password doesn't match, try again")]

        public string Verify { get; set; }



        public DateTime UserDateTime { get; set; }



        public int UserId { get; set; }

        private static int nextId = 1;



        public AddUserViewModel()

        {

            UserId = nextId;

            nextId++;

            UserDateTime = DateTime.Now;

        }
    }
}
