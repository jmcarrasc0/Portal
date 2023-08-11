using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioImagenes", Schema = "P1")]
public partial class UsuarioImagenes
{
    [Key]
    public Guid IDUsuarioImagen { get; set; }

    public Guid IDUsuario { get; set; }

    public Guid IDArchivo { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UsuarioImagenesCreatedByNavigation")]
    public virtual Usuarios CreatedByNavigation { get; set; } = null!;

    [ForeignKey("IDArchivo")]
    [InverseProperty("UsuarioImagenes")]
    public virtual Archivos IDArchivoNavigation { get; set; } = null!;

    [ForeignKey("IDUsuario")]
    [InverseProperty("UsuarioImagenesIDUsuarioNavigation")]
    public virtual Usuarios IDUsuarioNavigation { get; set; } = null!;
}
