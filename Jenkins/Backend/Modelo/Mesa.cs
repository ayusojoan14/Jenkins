using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("mesa")]
[Index("IdRestaurante", Name = "mesa_fk_restaurante")]
public partial class Mesa
{
    [Key]
    [Column("ID_Mesa")]
    public int IdMesa { get; set; }

    [Column("ID_Restaurante")]
    public int? IdRestaurante { get; set; }

    public int? Numero { get; set; }

    public int? Capacidad { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [InverseProperty("IdMesaNavigation")]
    public virtual ICollection<DisponibilidadMesa> DisponibilidadMesas { get; set; } = new List<DisponibilidadMesa>();

    [ForeignKey("IdRestaurante")]
    [InverseProperty("Mesas")]
    public virtual Restaurante? IdRestauranteNavigation { get; set; }

    [ForeignKey("IdMesa")]
    [InverseProperty("IdMesas")]
    public virtual ICollection<Reserva> IdReservas { get; set; } = new List<Reserva>();
}
