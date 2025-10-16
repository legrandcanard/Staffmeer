
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class Employee
{
    public int Id { get; set; }

    [DisplayName("Имя")]
    public string FirstName { get; set; } = null!;

    [DisplayName("Фамилия")]
    public string LastName { get; set; } = null!;

    [DisplayName("Отчество")]
    public string Patronymic { get; set; } = null!;

    public int DepartmentId { get; set; }

    [DisplayName("Отдел")]
    public virtual Departament Department { get; set; } = null!;

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee1s { get; set; } = new List<ProvisionRecord>();

    public virtual ICollection<ProvisionRecord> ProvisionRecordEmployee2s { get; set; } = new List<ProvisionRecord>();

    public string FullName => $"{LastName} {FirstName} {Patronymic}";
}
