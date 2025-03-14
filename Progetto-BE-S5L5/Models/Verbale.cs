using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Progetto_BE_S5L5.Models;

[Table("Verbale")]
public partial class Verbale
{
    [Key]
    [Column("idVerbale")]
    public Guid IdVerbale { get; set; }

    public DateOnly DataViolazione { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string IndirizzoViolazione { get; set; } = null!;

    [StringLength(100)]
    public string NominativoAgente { get; set; } = null!;

    public DateOnly DataTrascrizioneVerbale { get; set; }

    [Column(TypeName = "decimal(9, 2)")]
    public decimal Importo { get; set; }

    public int DecurtamentoPunti { get; set; }

    [Column("idanagrafica")]
    public Guid Idanagrafica { get; set; }

    [Column("idviolazione")]
    public Guid Idviolazione { get; set; }

    [ForeignKey("Idanagrafica")]
    [InverseProperty("Verbales")]
    public virtual Anagrafica IdanagraficaNavigation { get; set; } = null!;

    [ForeignKey("Idviolazione")]
    [InverseProperty("Verbales")]
    public virtual Violazione IdviolazioneNavigation { get; set; } = null!;
}
