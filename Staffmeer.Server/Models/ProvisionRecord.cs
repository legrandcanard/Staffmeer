using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class ProvisionRecord
{
    [DisplayName("Номер")]
    public int Id { get; set; }

    [DisplayName("Дата")]
    public DateTime Date { get; set; }

    public int Nomenclature1Id { get; set; }

    public int Nomenclature2Id { get; set; }

    public int Employee1Id { get; set; }

    public int Employee2Id { get; set; }

    public int? CounterpartyId { get; set; }

    public int ProvisionRecordTypeId { get; set; }

    [DisplayName("Комментарий")]
    public string Description { get; set; }

    [DisplayName("Контрагент")]
    public virtual Counterparty Counterparty { get; set; }

    [DisplayName("Сотрудник 1")]
    public virtual Employee Employee1 { get; set; }

    [DisplayName("Сотрудник 2")]
    public virtual Employee Employee2 { get; set; }

    [DisplayName("Номенклатура 1")]
    public virtual Nomenclature Nomenclature1 { get; set; }

    [DisplayName("Номенклатура 2")]
    public virtual Nomenclature Nomenclature2 { get; set; }

    [DisplayName("Тип")]
    public virtual ProvisionRecordType ProvisionRecordType { get; set; }
}
