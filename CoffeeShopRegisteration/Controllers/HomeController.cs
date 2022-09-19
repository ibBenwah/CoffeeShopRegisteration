using CoffeeShopRegisteration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeShopRegisteration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserContext context = new UserContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult AddUserToDb(User user) 
        {
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("GetUsers");
        }

        public IActionResult GetUsers()
        {
            List<User> user = context.Users.ToList();
            return View(user);
        }
        public IActionResult WelcomeUser(User user)
        {
            Console.WriteLine($"Welcome {user.FirstName} {user.LastName}");
            return View();
        }
    }
}