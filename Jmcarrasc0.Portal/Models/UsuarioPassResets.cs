using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioPassResets", Schema = "P1")]
public partial class UsuarioPassResets
{
    [Key]
    public Guid IDUsuarioPassReset { get; set; }

    public Guid IDUsuarioPass { get; set; }

    public DateTime createdOn { get; set; }
}
