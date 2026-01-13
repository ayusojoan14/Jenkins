using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("reservas")]
[Index("DniCliente", Name = "DNI_Cliente")]
[Index("IdPersonal", Name = "ID_Personal")]
public partial class Reserva
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DNI_Cliente")]
    [StringLength(20)]
    public string? DniCliente { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column(TypeName = "time")]
    public TimeSpan? Hora { get; set; }

    [Column("Numero_Personas")]
    public int? NumeroPersonas { get; set; }

    [Column("ID_Personal")]
    public int? IdPersonal { get; set; }

    [ForeignKey("DniCliente")]
    [InverseProperty("Reservas")]
    public virtual Cliente? DniClienteNavigation { get; set; }

    [ForeignKey("IdPersonal")]
    [InverseProperty("Reservas")]
    public virtual Personal? IdPersonalNavigation { get; set; }

    [ForeignKey("IdReserva")]
    [InverseProperty("IdReservas")]
    public virtual ICollection<Mesa> IdMesas { get; set; } = new List<Mesa>();
}
