using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class Employee
{
    public int Id { get; set; }

    [DisplayName("Имя")]
    public string FirstName { get; set; }

    [DisplayName("Фамилия")]
    public string LastName { get; set; }

    [DisplayName("Отчество")]
    public string Patronymic { get; set; }

    public int DepartmentId { get; set; }

    [DisplayName("Отдел")]
    public virtual Departament Department { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee1s { get; set; } = new List<ProvisionRecord>();

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee2s { get; set; } = new List<ProvisionRecord>();
}
