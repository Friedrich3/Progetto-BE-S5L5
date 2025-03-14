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

        private async Task<bool> SaveAsync()
        { try {
                var righe = await _context.SaveChangesAsync();
                if (righe > 0)
                { return true;
                }else{
                    return false;
                }}catch
            {return false;}}

        public async Task<string> GetRole()
        {
            //TODO: Da sostituire con una vera autenticazione del ruolo 
            //Da sostituire con "admin" per visualizzare diversi bottoni nella View
            var ruolo = "admin";
            return ruolo;
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

        public async Task<bool> DeleteViolazione(Guid verbaleId)
        {
            var viol = await _context.Verbales.FindAsync(verbaleId);
            if (viol == null)
            {
                return false;
            }
            _context.Verbales.Remove(viol);
            return await SaveAsync();


        }

    }
}
