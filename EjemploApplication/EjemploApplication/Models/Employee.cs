using System.ComponentModel.DataAnnotations;

namespace EjemploApplication.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        // RFC Validation attribute
        [Required, StringLength(13, MinimumLength = 12)]
        [RegularExpression(@"^[A-Z]{4}\d{6}[A-Z0-9]{3}$", ErrorMessage = "Invalid RFC format")]
        public string RFC { get; set; }

        public DateTime BornDate { get; set; }
        public EmployeeStatus Status { get; set; } = EmployeeStatus.NotSet;
    }

}
