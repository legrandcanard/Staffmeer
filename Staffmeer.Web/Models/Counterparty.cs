using System;
using System.Collections.Generic;

namespace Staffmeer.Web.Models;

public partial class Counterparty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();

    public virtual ICollection<ProvisionRecord> ProvisionRecords { get; set; } = new List<ProvisionRecord>();
}
