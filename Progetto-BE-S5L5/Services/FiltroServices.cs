using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Services
{
    public class FiltroServices
    {
        private readonly ApplicationDbContext _context;
        public FiltroServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ViolazioneViewModel> TotVerbXAnag()
        {
            try
            {
                var Lista = new ViolazioneViewModel();
                Lista.ViolList = await _context.Anagraficas.Include(p => p.Verbales).ThenInclude(a => a.IdviolazioneNavigation).ToListAsync();
                return Lista;

            }
            catch
            {
                return new ViolazioneViewModel() { ViolList = new List<Anagrafica>() };
            }
        }

        public async Task<FiltroViewModel> TotPuntiPerAnag()
        {
            try
            {
                var Lista = new FiltroViewModel();
                Lista.Verbali = await _context.Verbales.ToListAsync();
                return Lista;

            }
            catch
            {
                return new FiltroViewModel() { Verbali = new List<Verbale>() };
            }
        }



        public async Task<FiltroViewModel> TotVerbOver10()
        {
            try
            {
                var Lista = new FiltroViewModel();
                Lista.Verbali = await _context.Verbales.Where(p=> p.DecurtamentoPunti >10).ToListAsync();
                return Lista;
            }
            catch
            {
                return new FiltroViewModel() { Verbali = new List<Verbale>() };
            }
        }

        public async Task<FiltroViewModel> TotCostVerbOver400()
        {
            try
            {
                var Lista = new FiltroViewModel();
                Lista.Verbali = await _context.Verbales.Where(p => p.Importo >= 400).ToListAsync();
                return Lista;
            }
            catch
            {
                return new FiltroViewModel() { Verbali = new List<Verbale>() };
            }
        }




    }
}
