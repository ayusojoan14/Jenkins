using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[PrimaryKey("IdPlato", "IdProducto")]
[Table("plato_producto")]
[Index("IdProducto", Name = "ID_Producto")]
public partial class PlatoProducto
{
    [Key]
    [Column("ID_Plato")]
    public int IdPlato { get; set; }

    [Key]
    [Column("ID_Producto")]
    public int IdProducto { get; set; }

    [Column("Cantidad_Necesaria")]
    [Precision(10)]
    public decimal? CantidadNecesaria { get; set; }

    [ForeignKey("IdPlato")]
    [InverseProperty("PlatoProductos")]
    public virtual Plato IdPlatoNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("PlatoProductos")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
