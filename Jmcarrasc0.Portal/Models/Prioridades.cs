using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Prioridades", Schema = "S1")]
public partial class Prioridades
{
    [Key]
    public Guid IDPrioridad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cod { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
