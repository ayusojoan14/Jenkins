using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("disponibilidad_mesa")]
[Index("IdMesa", Name = "ID_Mesa")]
public partial class DisponibilidadMesa
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_Mesa")]
    public int? IdMesa { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Fecha { get; set; }

    [Column("Hora_Inicio", TypeName = "time")]
    public TimeSpan? HoraInicio { get; set; }

    [Column("Hora_Fin", TypeName = "time")]
    public TimeSpan? HoraFin { get; set; }

    [ForeignKey("IdMesa")]
    [InverseProperty("DisponibilidadMesas")]
    public virtual Mesa? IdMesaNavigation { get; set; }
}
