using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }
    }
}
