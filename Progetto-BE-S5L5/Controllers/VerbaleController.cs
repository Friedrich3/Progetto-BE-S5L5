using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Services;

namespace Progetto_BE_S5L5.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleServices _verbaleServices;
        public VerbaleController(VerbaleServices verbaleServices)
        {
            _verbaleServices = verbaleServices;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
