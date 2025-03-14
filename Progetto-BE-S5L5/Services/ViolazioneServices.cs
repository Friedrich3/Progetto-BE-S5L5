using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Services
{
    public class ViolazioneServices
    {
        private readonly ApplicationDbContext _context;
        public ViolazioneServices(ApplicationDbContext context)
        {
            _context = context;
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

    }
}
