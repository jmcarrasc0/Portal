using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Jmcarrasc0.Portal.Models;

[Table("Pais", Schema = "S1")]
public partial class Pais
{
    [Key]
    public Guid IDPais { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
