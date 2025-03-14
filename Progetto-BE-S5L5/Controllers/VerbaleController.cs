using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Services;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleServices _verbaleServices;
        public VerbaleController(VerbaleServices verbaleServices)
        {
            _verbaleServices = verbaleServices;
        }



        public async Task<IActionResult> Index()
        {
            ViewBag.Violazioni = await _verbaleServices.GetViolation();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVerbale(VerbaleViewModel verbViewModel)
        {
            if (!ModelState.IsValid) {
                TempData["Error"] = "I dati inseriti non sono Validi";
                return RedirectToAction("Index");
            }
            
            var isAdded = await _verbaleServices.AddNewVerbale(verbViewModel);
            if (!isAdded)
            {
                TempData["Error"] = "Errore nel aggiunta del Verbale";
            }


            return RedirectToAction("Index");
        }
    }
}
