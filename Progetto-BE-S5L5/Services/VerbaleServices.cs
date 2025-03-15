using Microsoft.EntityFrameworkCore;
using Progetto_BE_S5L5.Data;
using Progetto_BE_S5L5.Models;
using Progetto_BE_S5L5.ViewModels;

namespace Progetto_BE_S5L5.Services
{
    public class VerbaleServices
    {
        private readonly ApplicationDbContext _context;
        public VerbaleServices(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
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

        public async Task<List<Violazione>> GetViolation()
        {
            try
            {
                var Lista = await _context.Violaziones.ToListAsync();
                if (Lista.Count > 0)
                {
                    return Lista;
                }
                else
                {
                    return new List<Violazione>();
                }
            }
            catch
            {

                return new List<Violazione>();
            }
        }

        public async Task<bool> AddNewVerbale(VerbaleViewModel verbViewModel)
        {
            var isReg = await _context.Anagraficas.FirstOrDefaultAsync(p => p.CodiceFiscale == verbViewModel.Anagrafica.CodiceFiscale);

            if (isReg != null) 
            {
                var verbale = new Verbale()
                {
                    IdVerbale = Guid.NewGuid(),
                    DataViolazione = verbViewModel.DataViolazione,
                    IndirizzoViolazione = verbViewModel.IndirizzoViolazione,
                    NominativoAgente = verbViewModel.NominativoAgente,
                    DataTrascrizioneVerbale = verbViewModel.DataTrascrizioneVerbale,
                    Importo = verbViewModel.Importo,
                    DecurtamentoPunti= verbViewModel.DecurtamentoPunti,
                    Idanagrafica = isReg.Idanagrafica,
                    Idviolazione = verbViewModel.Idviolazione
                };
                _context.Verbales.Add(verbale);
                return await SaveAsync();

            }
            else
            {
                var user = new Anagrafica()
                {
                    Idanagrafica = Guid.NewGuid(),
                    Cognome = verbViewModel.Anagrafica!.Cognome,
                    Nome = verbViewModel.Anagrafica.Nome,
                    Indirizzo = verbViewModel.Anagrafica.Indirizzo,
                    Citta = verbViewModel.Anagrafica.Citta,
                    Cap = verbViewModel.Anagrafica.Cap.ToString(),
                    CodiceFiscale = verbViewModel.Anagrafica.CodiceFiscale
                };
                var verbale = new Verbale()
                {
                    IdVerbale = Guid.NewGuid(),
                    DataViolazione = verbViewModel.DataViolazione,
                    IndirizzoViolazione = verbViewModel.IndirizzoViolazione,
                    NominativoAgente = verbViewModel.NominativoAgente,
                    DataTrascrizioneVerbale = verbViewModel.DataTrascrizioneVerbale,
                    Importo = verbViewModel.Importo,
                    DecurtamentoPunti = verbViewModel.DecurtamentoPunti,
                    Idanagrafica = user.Idanagrafica,
                    Idviolazione = verbViewModel.Idviolazione
                };
                _context.Anagraficas.Add(user);
                _context.Verbales.Add(verbale);
                return await SaveAsync();
            }
        }

        public async Task<EditVerbaleViewModel>FindEdit (Guid verbaleId)
        {
            var getVerbale = await _context.Verbales.Include(p => p.IdanagraficaNavigation).FirstOrDefaultAsync(p => p.IdVerbale == verbaleId);    
            if (getVerbale == null)
            {
                return null;
            }
            var verbale = new EditVerbaleViewModel()
            {
                IdVerbale = verbaleId,
                DataViolazione = getVerbale.DataViolazione,
                IndirizzoViolazione = getVerbale.IndirizzoViolazione,
                NominativoAgente= getVerbale.NominativoAgente,
                DataTrascrizioneVerbale = getVerbale.DataTrascrizioneVerbale,
                Importo = getVerbale.Importo,
                DecurtamentoPunti = getVerbale.DecurtamentoPunti,
                Idviolazione = getVerbale.Idviolazione,
                Anagrafica = getVerbale.IdanagraficaNavigation,
            };
            return verbale;
        }

        public async Task<bool> SaveEdit (EditVerbaleViewModel editViewModel, Guid verbaleId)
        {
            var getVerbale = await _context.Verbales.Include(p => p.IdanagraficaNavigation).FirstOrDefaultAsync(p => p.IdVerbale == verbaleId);
            if (getVerbale == null)
            {
                return false;
            }
            getVerbale.DataViolazione = editViewModel.DataViolazione;
            getVerbale.IndirizzoViolazione = editViewModel.IndirizzoViolazione;
            getVerbale.Idviolazione = editViewModel.Idviolazione;
            getVerbale.Importo = editViewModel.Importo;
            getVerbale.DecurtamentoPunti = editViewModel.DecurtamentoPunti;
            getVerbale.DataTrascrizioneVerbale = editViewModel.DataTrascrizioneVerbale;
            getVerbale.NominativoAgente = editViewModel.NominativoAgente;
            return await SaveAsync();
        }

    }
}
