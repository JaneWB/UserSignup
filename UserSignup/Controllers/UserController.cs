using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;
using UserSignup.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(UserData.GetAll());
        }

        public IActionResult Add()
        {
            return View(new AddUserViewModel());
        }

        [HttpPost]

        public IActionResult Add(AddUserViewModel addUserViewModel, string verify)

        {

            User newUser = new User()

            {

                Username = addUserViewModel.Username,

                Email = addUserViewModel.Email,

                Password = addUserViewModel.Password,

                Verify = addUserViewModel.Verify,

                UserId = addUserViewModel.UserId,

                UserDateTime = addUserViewModel.UserDateTime

            };

            if (ModelState.IsValid && verify == newUser.Password)

            {

                UserData.Add(newUser);

                return Redirect("/User/Index");

            }



            return View("Add", addUserViewModel);

        }



        public IActionResult Details(User myUser)

        {

            int id = myUser.UserId;

            var user = UserData.GetById(id);

            return View(user);

        }
    }
}
