using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioEstatus", Schema = "P1")]
public partial class UsuarioEstatus
{
    [Key]
    public Guid IDUsuarioEstatus { get; set; }

    public Guid IDUsuario { get; set; }

    public Guid IDEstatus { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    [ForeignKey("IDEstatus")]
    [InverseProperty("UsuarioEstatus")]
    public virtual Estatus IDEstatusNavigation { get; set; } = null!;

    [ForeignKey("IDUsuario")]
    [InverseProperty("UsuarioEstatus")]
    public virtual Usuarios IDUsuarioNavigation { get; set; } = null!;
}
