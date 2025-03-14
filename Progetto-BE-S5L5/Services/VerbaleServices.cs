using Progetto_BE_S5L5.Data;

namespace Progetto_BE_S5L5.Services
{
    public class VerbaleServices
    {
        private readonly ApplicationDbContext _context;
        public VerbaleServices(ApplicationDbContext context)
        {
            _context = context;
        }



    }
}
