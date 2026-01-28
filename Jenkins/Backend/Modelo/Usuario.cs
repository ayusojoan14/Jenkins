using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("usuario")]
[Index("Username", Name = "Username", IsUnique = true)]
[Index("DniCliente", Name = "usuario_fk_cliente")]
[Index("IdPersonal", Name = "usuario_fk_personal")]
[Index("RolId", Name = "usuario_fk_rol")]
public partial class Usuario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

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
