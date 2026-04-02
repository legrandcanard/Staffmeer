namespace Staffmeer.Server.Models
{
    public partial class Nomenclature
    {
        public string FullName => $"{Brandname?.Name ?? "" } {Name} (#{SerialNumber})";
    }
}
