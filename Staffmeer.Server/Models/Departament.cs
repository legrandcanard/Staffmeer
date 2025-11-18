using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Staffmeer.Server.Models;

public partial class Departament
{
    public int Id { get; set; }

    [DisplayName("Наименование")]
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
