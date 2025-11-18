using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class ProvisionRecordType
{
    public int Id { get; set; }

    [DisplayName("Наименование")]
    public string Name { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecords { get; set; } = new List<ProvisionRecord>();
}
