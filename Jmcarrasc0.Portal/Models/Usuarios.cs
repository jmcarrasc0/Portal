using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Usuarios", Schema = "P1")]
public partial class Usuarios
{
    [Key]
    public Guid IDUsuario { get; set; }

    public string UserName { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [InverseProperty("IDUsuarioNavigation")]
    public virtual ICollection<UsuarioEstatus> UsuarioEstatus { get; set; } = new List<UsuarioEstatus>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<UsuarioImagenes> UsuarioImagenesCreatedByNavigation { get; set; } = new List<UsuarioImagenes>();

    [InverseProperty("IDUsuarioNavigation")]
    public virtual ICollection<UsuarioImagenes> UsuarioImagenesIDUsuarioNavigation { get; set; } = new List<UsuarioImagenes>();

    [InverseProperty("IDUsuarioNavigation")]
    public virtual ICollection<UsuarioPass> UsuarioPass { get; set; } = new List<UsuarioPass>();

    [InverseProperty("IDUsuarioNavigation")]
    public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; } = new List<UsuarioRoles>();
}
