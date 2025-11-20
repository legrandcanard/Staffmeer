using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class Nomenclature
{
    public int Id { get; set; }

    [DisplayName("Серийный номер")]
    public string SerialNumber { get; set; }

    [DisplayName("Наименование")]
    public string Name { get; set; }

    public int NomenclatureTypeId { get; set; }

    public int BrandnameId { get; set; }

    public int? CounterpartyId { get; set; }

    public int? EmployeeId { get; set; }

    [DisplayName("Бренд")]
    public virtual Brandname Brandname { get; set; }

    [DisplayName("Контрагент")]
    public virtual Counterparty Counterparty { get; set; }

    [DisplayName("Сотрудник")]
    public virtual Employee Employee { get; set; }

    [DisplayName("Тип номенклатуры")]
    public virtual NomenclatureType NomenclatureType { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecordNomenclature1s { get; set; } = new List<ProvisionRecord>();

    public virtual ICollection<ProvisionRecord> ProvisionRecordNomenclature2s { get; set; } = new List<ProvisionRecord>();
}
