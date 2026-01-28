using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[PrimaryKey("IdPedido", "IdPlato")]
[Table("pedido_plato")]
[Index("IdPlato", Name = "pedido_plato_ibfk_2")]
public partial class PedidoPlato
{
    [Key]
    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Key]
    [Column("ID_Plato")]
    public int IdPlato { get; set; }

    public int? Cantidad { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("PedidoPlatos")]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    [ForeignKey("IdPlato")]
    [InverseProperty("PedidoPlatos")]
    public virtual Plato IdPlatoNavigation { get; set; } = null!;
}
