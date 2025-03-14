using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Services
{
    public class ViolazioneServices
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailServices _emailServices;
        public ViolazioneServices(ApplicationDbContext context, EmailServices emailServices)
        {
            _context = context;
            _emailServices = emailServices;
        }


        public async Task<ViolazioneViewModel> GetAll()
        {
            try
            {
                var Lista = new ViolazioneViewModel();
                Lista.ViolList = await _context.Anagraficas.Include(p => p.Verbales).ThenInclude(a => a.IdviolazioneNavigation).ToListAsync();
                return Lista;
            }
            catch (Exception)
            {
                var Lista = new ViolazioneViewModel() { ViolList = new List<Anagrafica>()};
                return Lista;
            }
        }

        public async Task<bool> Contest(Guid verbaleId)
        {
            var Verbale = await _context.Verbales.Include(p => p.IdanagraficaNavigation).FirstOrDefaultAsync(p => p.IdVerbale == verbaleId);
            var isNotified = await _emailServices.SendNotify(Verbale.IdanagraficaNavigation.Cognome, Verbale.IdanagraficaNavigation.Nome, Verbale.IdVerbale);
            return isNotified;
        }

    }
}
