using Progetto_BE_S5L5.Data;

namespace Progetto_BE_S5L5.Services
{
    public class ViolazioneServices
    {
        private readonly ApplicationDbContext _context;
        public ViolazioneServices(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
