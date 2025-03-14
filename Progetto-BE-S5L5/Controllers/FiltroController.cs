using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.Services;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Controllers
{
    public class FiltroController : Controller
    {
        private readonly FiltroServices _filtroServices;
        public FiltroController(FiltroServices filtroServices)
        {
            _filtroServices = filtroServices;
        }


        public async Task<IActionResult> Index(string query)
        {
            FiltroViewModel Lista;
            switch (query)
            {
                case "1":
                    ViolazioneViewModel Lista1;
                    Lista1 = await _filtroServices.TotVerbXAnag();
                    return View("Index", Lista1);


                case "2":

                    Lista = await _filtroServices.TotPuntiPerAnag();
                    return View("TotPuntiPerAnag", Lista);

                case "3":

                    Lista = await _filtroServices.TotVerbOver10();
                    return View("TotVerbOver10", Lista);

                    
                case "4":

                    Lista = await _filtroServices.TotCostVerbOver400();
                    return View("TotCostVerbOver400", Lista);



                default:
                    Lista = new FiltroViewModel() { Verbali = new List<Verbale>() };
                    return View(Lista);

            }
            
        }
    }
}
