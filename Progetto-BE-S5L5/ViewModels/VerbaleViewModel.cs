using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Progetto_BE_S5L5.ViewModels
{
    public class VerbaleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataViolazione { get; set; }

        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string IndirizzoViolazione { get; set; } = null!;

        [StringLength(100)]
        public string NominativoAgente { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DataTrascrizioneVerbale { get; set; }

        [Required]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Importo { get; set; }

        [Required]
        public int DecurtamentoPunti { get; set; } = 0;

        [Required]
        public Guid Idviolazione { get; set; }

        public AnagraficaAddViewModel? Anagrafica { get; set; }
    }
}
