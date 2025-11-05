using System;
using System.Collections.Generic;

namespace Staffmeer.Server.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
