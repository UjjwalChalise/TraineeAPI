using Microsoft.AspNetCore.Mvc;

namespace TraineeAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
