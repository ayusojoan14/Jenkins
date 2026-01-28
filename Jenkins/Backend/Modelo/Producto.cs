using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("producto")]
public partial class Producto
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Nombre_Ingredientes")]
    [StringLength(100)]
    public string? NombreIngredientes { get; set; }

    [Column("Cantidad_Disponible")]
    public int? CantidadDisponible { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<PlatoProducto> PlatoProductos { get; set; } = new List<PlatoProducto>();

    [ForeignKey("IdProducto")]
    [InverseProperty("IdProductos")]
    public virtual ICollection<Proveedor> IdProveedors { get; set; } = new List<Proveedor>();
}
