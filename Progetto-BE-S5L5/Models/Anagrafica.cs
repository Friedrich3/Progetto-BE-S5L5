using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Progetto_BE_S5L5.Models;

[Table("Anagrafica")]
[Index("CodiceFiscale", Name = "Unique_CF", IsUnique = true)]
public partial class Anagrafica
{
    [Key]
    [Column("idanagrafica")]
    public Guid Idanagrafica { get; set; }

    [StringLength(50)]
    public string Cognome { get; set; } = null!;

    [StringLength(50)]
    public string Nome { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Indirizzo { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Citta { get; set; } = null!;

    public int Cap { get; set; }

    [Column("Codice_Fiscale")]
    [StringLength(16)]
    [Unicode(false)]
    public string CodiceFiscale { get; set; } = null!;

    [InverseProperty("IdanagraficaNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}
