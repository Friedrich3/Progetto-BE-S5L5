using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Services;

namespace Progetto_BE_S5L5.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaServices _anagraficaServices;
        public AnagraficaController( AnagraficaServices anagraficaServices)
        {
            _anagraficaServices = anagraficaServices;
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
