using System;
using System.Collections.Generic;

namespace Staffmeer.Persistent.Models;

public partial class ProvisionRecord
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int Nomenclature1Id { get; set; }

    public int Nomenclature2Id { get; set; }

    public int Employee1Id { get; set; }

    public int Employee2Id { get; set; }

    public int? CounterpartyId { get; set; }

    public int ProvisionRecordTypeId { get; set; }

    public string? Description { get; set; }

    public virtual Counterparty? Counterparty { get; set; }

    public virtual Employee Employee1 { get; set; } = null!;

    public virtual Employee Employee2 { get; set; } = null!;

    public virtual Nomenclature Nomenclature1 { get; set; } = null!;

    public virtual Nomenclature Nomenclature2 { get; set; } = null!;

    public virtual ProvisionRecordType ProvisionRecordType { get; set; } = null!;
}
