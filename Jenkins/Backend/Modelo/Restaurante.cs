using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jenkins.Backend.Modelo;

[Table("restaurante")]
public partial class Restaurante
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(255)]
    public string Direccion { get; set; } = null!;

    [InverseProperty("IdRestauranteNavigation")]
    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();

    [InverseProperty("IdRestauranteNavigation")]
    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
