using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Estatus", Schema = "S1")]
public partial class Estatus
{
    [Key]
    public Guid IDEstatus { get; set; }

    public string Nombre { get; set; } = null!;

    public long Codigo { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    [InverseProperty("IDEstatusNavigation")]
    public virtual ICollection<UsuarioEstatus> UsuarioEstatus { get; set; } = new List<UsuarioEstatus>();
}
