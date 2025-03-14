using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Progetto_BE_S5L5.Models;

[Table("Violazione")]
public partial class Violazione
{
    [Key]
    [Column("idviolazione")]
    public Guid Idviolazione { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Descrizione { get; set; } = null!;

    [InverseProperty("IdviolazioneNavigation")]
    public virtual ICollection<Verbale> Verbales { get; set; } = new List<Verbale>();
}
