using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models;
using MvcStartApp.Models.Db.Repositories;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class FeedbackController: Controller
    {
        private readonly ILogger<FeedbackController> _logger;
        private readonly IBlogRepository _repo;
        public FeedbackController(ILogger<FeedbackController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        ///  Метод, возвращающий страницу с отзывами
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Метод для Ajax-запросов
        /// </summary>
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });    
        }
    }
}
