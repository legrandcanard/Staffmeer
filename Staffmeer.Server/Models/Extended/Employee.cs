namespace Staffmeer.Server.Models
{
    public partial class Employee
    {
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
    }
}
