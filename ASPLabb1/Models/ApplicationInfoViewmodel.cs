using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models
{
    public class ApplicationInfoViewmodel
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public String EmployeeName { get; set; }
        public string? VacationType { get; set; }
    }
}
