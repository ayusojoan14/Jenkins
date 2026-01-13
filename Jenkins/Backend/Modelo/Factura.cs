using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("factura")]
[Index("IdPedido", Name = "ID_Pedido", IsUnique = true)]
public partial class Factura
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Precision(10)]
    public decimal? Total { get; set; }

    [Column("IVA")]
    [Precision(5)]
    public decimal? Iva { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaPago { get; set; }

    [StringLength(50)]
    public string? MetodoPago { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("Factura")]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
