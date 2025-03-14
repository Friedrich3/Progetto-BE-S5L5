using Microsoft.AspNetCore.Mvc;
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
            ViolazioneViewModel Lista;
            switch (query)
            {
                case "1":
                    


                    return View();
                case "2":



                    return View();
                case "3":



                    return View();
                case "4":



                    return View();


                default:
                    return View();

            }
            
        }
    }
}
