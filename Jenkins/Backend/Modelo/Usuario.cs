using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("usuario")]
[Index("DniCliente", Name = "DNI_Cliente")]
[Index("IdPersonal", Name = "ID_Personal")]
[Index("Username", Name = "Username", IsUnique = true)]
[Index("RolId", Name = "rol_id")]
public partial class Usuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "enum('CLIENTE','EMPLEADO')")]
    public string Tipo { get; set; } = null!;

    [Column("ID_Personal")]
    public int? IdPersonal { get; set; }

    [Column("DNI_Cliente")]
    [StringLength(20)]
    public string? DniCliente { get; set; }

    [Column("rol_id")]
    public int? RolId { get; set; }

    [ForeignKey("DniCliente")]
    [InverseProperty("Usuarios")]
    public virtual Cliente? DniClienteNavigation { get; set; }

    [ForeignKey("IdPersonal")]
    [InverseProperty("Usuarios")]
    public virtual Personal? IdPersonalNavigation { get; set; }

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Rol? Rol { get; set; }
}
