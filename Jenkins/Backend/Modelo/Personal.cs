using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("personal")]
[Index("HorarioId", Name = "personal_fk_horario")]
[Index("IdRestaurante", Name = "personal_fk_restaurante")]
[Index("RolId", Name = "personal_fk_rol")]
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

    [Column("Horario_ID")]
    public int? HorarioId { get; set; }

    [Column("rol_id")]
    public int? RolId { get; set; }

    [Column("ID_Restaurante")]
    public int? IdRestaurante { get; set; }

    [StringLength(100)]
    public string? Contacto { get; set; }

    [ForeignKey("HorarioId")]
    [InverseProperty("Personals")]
    public virtual Horario? Horario { get; set; }

    [ForeignKey("IdRestaurante")]
    [InverseProperty("Personals")]
    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    [InverseProperty("IdPersonalNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [ForeignKey("RolId")]
    [InverseProperty("Personals")]
    public virtual Rol? Rol { get; set; }

    [InverseProperty("IdPersonalNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [ForeignKey("IdPersonal")]
    [InverseProperty("IdPersonals")]
    public virtual ICollection<Plato> IdPlatos { get; set; } = new List<Plato>();
}
