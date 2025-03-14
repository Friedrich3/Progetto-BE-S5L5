using Progetto_BE_S5L5.Data;

namespace Progetto_BE_S5L5.Services
{
    public class AnagraficaServices
    {
        private readonly ApplicationDbContext _context;
        public AnagraficaServices(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}
