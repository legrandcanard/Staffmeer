using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class NomenclatureType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();
}
