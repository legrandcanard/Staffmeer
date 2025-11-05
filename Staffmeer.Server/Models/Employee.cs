using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public int DepartmentId { get; set; }

    public virtual Departament Department { get; set; }

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee1s { get; set; } = new List<ProvisionRecord>();

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee2s { get; set; } = new List<ProvisionRecord>();
}
