using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class Nomenclature
{
    public int Id { get; set; }

    public string SerialNumber { get; set; }

    public string Name { get; set; }

    public int NomenclatureTypeId { get; set; }

    public int BrandnameId { get; set; }

    public int? CounterpartyId { get; set; }

    public virtual Brandname Brandname { get; set; }

    public virtual Counterparty Counterparty { get; set; }

    public virtual NomenclatureType NomenclatureType { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecordNomenclature1s { get; set; } = new List<ProvisionRecord>();

    public virtual ICollection<ProvisionRecord> ProvisionRecordNomenclature2s { get; set; } = new List<ProvisionRecord>();
}
