using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Progetto_BE_S5L5.Models;

namespace Progetto_BE_S5L5.ViewModels
{
    public class EditVerbaleViewModel
    {
        [Required]
        public Guid IdVerbale { get; set; }
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

        public Anagrafica? Anagrafica { get; set; }
    }
}
