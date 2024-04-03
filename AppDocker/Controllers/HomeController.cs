using AppDocker.Entities;
using AppDocker.Models;
using AppDocker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly IUser _userService;

        public HomeController(
            IUser userService
            )
        {
            _userService = userService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("AddUser")]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromForm] AddUserBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var userAlreadyExists = _userService.ExistUser(model.Email);
                if (userAlreadyExists)
                {
                    ModelState.AddModelError(nameof(model.Email), "User is already exist");
                    return View(model);
                }
                var newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };
                await _userService.CreateUser(newUser);
                return RedirectToAction("UsersList");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet("UsersList")]
        public async Task<IActionResult> UsersList()
        {
            var user = await this._userService.GetUser();

            if (user != null && user.Any())
            {
                return View(user);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
