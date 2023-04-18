using System.ComponentModel.DataAnnotations;

namespace ASPLabb1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
