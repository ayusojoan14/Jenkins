using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("plato")]
public partial class Plato
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [Precision(10)]
    public decimal? Precio { get; set; }

    [InverseProperty("IdPlatoNavigation")]
    public virtual ICollection<PedidoPlato> PedidoPlatos { get; set; } = new List<PedidoPlato>();

    [InverseProperty("IdPlatoNavigation")]
    public virtual ICollection<PlatoProducto> PlatoProductos { get; set; } = new List<PlatoProducto>();

    [ForeignKey("IdPlato")]
    [InverseProperty("IdPlatos")]
    public virtual ICollection<Personal> IdPersonals { get; set; } = new List<Personal>();
}
