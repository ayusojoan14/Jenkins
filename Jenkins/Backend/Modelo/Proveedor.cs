using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("proveedor")]
public partial class Proveedor
{
    [Key]
    [Column("ID_Proveedor")]
    public int IdProveedor { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Contacto { get; set; }

    [ForeignKey("IdProveedor")]
    [InverseProperty("IdProveedors")]
    public virtual ICollection<Producto> IdProductos { get; set; } = new List<Producto>();
}
