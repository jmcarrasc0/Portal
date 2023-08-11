using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Roles", Schema = "S1")]
public partial class Roles
{
    [Key]
    public Guid IDRol { get; set; }

    public string Nombre { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [InverseProperty("IDRolNavigation")]
    public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; } = new List<UsuarioRoles>();
}
