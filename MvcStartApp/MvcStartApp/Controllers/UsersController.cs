using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Db.Repositories;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class UsersController: Controller
    {
        private readonly IBlogRepository _repo;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IBlogRepository repo, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }

 
        public async Task<IActionResult> Register(string FirstName, string LastName )
        {
            var newUser = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
            };
            await _repo.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
        }
    }
}
