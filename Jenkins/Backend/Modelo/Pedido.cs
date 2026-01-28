using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("pedidos")]
[Index("DniCliente", Name = "pedidos_ibfk_1")]
public partial class Pedido
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DNI_Cliente")]
    [StringLength(20)]
    public string? DniCliente { get; set; }

    public int? Cantidad { get; set; }

    [Column("Metodo_Pago")]
    [StringLength(50)]
    public string? MetodoPago { get; set; }

    [Column("Notas_Especiales", TypeName = "text")]
    public string? NotasEspeciales { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("DniCliente")]
    [InverseProperty("Pedidos")]
    public virtual Cliente? DniClienteNavigation { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual Factura? Factura { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<PedidoBebidum> PedidoBebida { get; set; } = new List<PedidoBebidum>();

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<PedidoPlato> PedidoPlatos { get; set; } = new List<PedidoPlato>();
}
