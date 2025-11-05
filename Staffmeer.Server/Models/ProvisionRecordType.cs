using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class ProvisionRecordType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecords { get; set; } = new List<ProvisionRecord>();
}
