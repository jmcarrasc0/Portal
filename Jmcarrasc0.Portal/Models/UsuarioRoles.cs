using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioRoles", Schema = "P1")]
public partial class UsuarioRoles
{
    [Key]
    public Guid IDUsuarioRol { get; set; }

    public Guid IDUsuario { get; set; }

    public Guid IDRol { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("IDRol")]
    [InverseProperty("UsuarioRoles")]
    public virtual Roles IDRolNavigation { get; set; } = null!;

    [ForeignKey("IDUsuario")]
    [InverseProperty("UsuarioRoles")]
    public virtual Usuarios IDUsuarioNavigation { get; set; } = null!;
}
