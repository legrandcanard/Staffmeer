using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class Brandname
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();
}
