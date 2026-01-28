using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("DNI")]
    [StringLength(20)]
    public string Dni { get; set; } = null!;

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Contacto { get; set; }

    [Column(TypeName = "text")]
    public string? Preferencias { get; set; }

    [InverseProperty("DniClienteNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [InverseProperty("DniClienteNavigation")]
    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    [InverseProperty("DniClienteNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
