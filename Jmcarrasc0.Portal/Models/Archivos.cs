using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Archivos", Schema = "P1")]
public partial class Archivos
{
    [Key]
    public Guid IDArchivo { get; set; }

    public byte[] Archivo { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    [InverseProperty("IDArchivoNavigation")]
    public virtual ICollection<UsuarioImagenes> UsuarioImagenes { get; set; } = new List<UsuarioImagenes>();
}
