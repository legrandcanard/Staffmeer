using System;
using System.Collections.Generic;

namespace Staffmeer.Web.Models;

public partial class NomenclatureType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();
}
