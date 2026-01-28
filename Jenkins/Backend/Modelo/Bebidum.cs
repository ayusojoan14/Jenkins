using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("bebida")]
public partial class Bebidum
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [Precision(10)]
    public decimal? Precio { get; set; }

    [InverseProperty("IdBebidaNavigation")]
    public virtual ICollection<PedidoBebidum> PedidoBebida { get; set; } = new List<PedidoBebidum>();
}
