using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class Counterparty
{
    public int Id { get; set; }

    [DisplayName("Наименование")]
    public string Name { get; set; }

    [DisplayName("Номер телефона")]
    public string PhoneNumber { get; set; }

    [DisplayName("Адрес")]
    public string Address { get; set; }

    public virtual ICollection<Nomenclature> Nomenclatures { get; set; } = new List<Nomenclature>();

    public virtual ICollection<ProvisionRecord> ProvisionRecords { get; set; } = new List<ProvisionRecord>();
}
