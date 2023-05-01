using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models
{
    public class VacationApplication
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int EmployeeId { get; set; }
        public string? VacationType{ get; set; }
    }
}
