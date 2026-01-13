using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("personal")]
public partial class Personal
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DN")]
    [StringLength(20)]
    public string? Dn { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(150)]
    public string? Apellidos { get; set; }

    [StringLength(100)]
    public string? Roles { get; set; }

    [StringLength(100)]
    public string? Contacto { get; set; }

    [InverseProperty("IdPersonalNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [InverseProperty("IdPersonalNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [ForeignKey("IdPersonal")]
    [InverseProperty("IdPersonals")]
    public virtual ICollection<Plato> IdPlatos { get; set; } = new List<Plato>();
}
