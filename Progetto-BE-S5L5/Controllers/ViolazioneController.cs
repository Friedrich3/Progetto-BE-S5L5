using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Progetto_BE_S5L5.Services;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneServices _violazioneServices;
        public ViolazioneController(ViolazioneServices violazioneServices)
        {
            _violazioneServices = violazioneServices;
        }

        public async Task<IActionResult> Index()
        {
            var Lista = await _violazioneServices.GetAll();

            return View(Lista);
        }

        public async Task<IActionResult> SendNotify(Guid verbaleId)
        {
            var isNotified = await _violazioneServices.Contest(verbaleId);
            if (!isNotified)
            {
                TempData["Error"] = "Errore nel Notifica dell'ordine ";
            }
            return RedirectToAction("Index");
        }
    }
}
