using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioPass", Schema = "P1")]
public partial class UsuarioPass
{
    [Key]
    public Guid IDUsuarioPass { get; set; }

    public Guid IDUsuario { get; set; }

    public string Pass { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("IDUsuario")]
    [InverseProperty("UsuarioPass")]
    public virtual Usuarios IDUsuarioNavigation { get; set; } = null!;
}
