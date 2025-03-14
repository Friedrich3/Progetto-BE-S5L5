using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Services;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaServices _anagraficaServices;
        public AnagraficaController( AnagraficaServices anagraficaServices)
        {
            _anagraficaServices = anagraficaServices;
        }


        public async Task<IActionResult> Index()
        {
            var Lista = await _anagraficaServices.GetAllAnagrafica();

            return View(Lista);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSave(AnagraficaAddViewModel addViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nella validazione dei dati nell'anagrafica";
                return RedirectToAction("Add");
            }

            var isAdded = await _anagraficaServices.AddNewAnag(addViewModel);
            if (!isAdded)
            {
                TempData["Error"] = "Errore durate l'aggiunta della persona nell'anagrafica";
            }

            return RedirectToAction("Index");
        }
    }
}
