using Staffmeer.Domain.Staff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffmeer.Domain.Staff.Repositories
{
    public interface IStaffRepository
    {
        Task<Employee> GetAllEmployees();
    }
}
