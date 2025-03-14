using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Services;

namespace Progetto_BE_S5L5.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneServices _violazioneServices;
        public ViolazioneController(ViolazioneServices violazioneServices)
        {
            _violazioneServices = violazioneServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
