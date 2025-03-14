using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Services
{
    public class AnagraficaServices
    {
        private readonly ApplicationDbContext _context;
        public AnagraficaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveChangeAsync()
        {
            try
            {
                var righe = await _context.SaveChangesAsync();
                if (righe > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public async Task<AnagraficaListViewModel> GetAllAnagrafica()
        {
            try
            {
            var Lista = new AnagraficaListViewModel();
            Lista.AnagList = await _context.Anagraficas.OrderBy(p=> p.Cognome).ToListAsync();
            return Lista;

            }
            catch 
            {
                return new AnagraficaListViewModel() { AnagList = new List<Anagrafica>()};
            }
        }
            
        public async Task<bool> AddNewAnag(AnagraficaAddViewModel addViewModel)
        {
            var newUser = new Anagrafica()
            {
                Idanagrafica = Guid.NewGuid(),
                Cognome = addViewModel.Cognome,
                Nome = addViewModel.Nome,
                CodiceFiscale = addViewModel.CodiceFiscale,
                Indirizzo = addViewModel.Indirizzo,
                Citta = addViewModel.Citta,
                Cap=addViewModel.Cap.ToString(),
            };
            _context.Anagraficas.Add(newUser);

            return await SaveChangeAsync();
        }



    }
}
