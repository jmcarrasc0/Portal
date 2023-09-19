using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("UsuarioPassCounts", Schema = "P1")]
public partial class UsuarioPassCounts
{
    [Key]
    public Guid IDUsuarioPassCount { get; set; }

    public Guid IDUsuarioPass { get; set; }

    public DateTime createdOn { get; set; }
}
