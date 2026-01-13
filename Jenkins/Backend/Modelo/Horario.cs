using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("horario")]
public partial class Horario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(30)]
    public string? Dia { get; set; }

    [Column("Hora_Entrada", TypeName = "time")]
    public TimeSpan HoraEntrada { get; set; }

    [Column("Hora_Salida", TypeName = "time")]
    public TimeSpan HoraSalida { get; set; }
}
