using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Department
    {
        [Key]
        public string DepartmentCode { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
