using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("permiso")]
public partial class Permiso
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(150)]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("PermisoId")]
    [InverseProperty("Permisos")]
    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
