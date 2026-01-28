using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[PrimaryKey("IdPedido", "IdBebida")]
[Table("pedido_bebida")]
[Index("IdBebida", Name = "ID_Bebida")]
public partial class PedidoBebidum
{
    [Key]
    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Key]
    [Column("ID_Bebida")]
    public int IdBebida { get; set; }

    public int? Cantidad { get; set; }

    [Column("Total_Linea")]
    [Precision(10)]
    public decimal? TotalLinea { get; set; }

    [ForeignKey("IdBebida")]
    [InverseProperty("PedidoBebida")]
    public virtual Bebidum IdBebidaNavigation { get; set; } = null!;

    [ForeignKey("IdPedido")]
    [InverseProperty("PedidoBebida")]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
