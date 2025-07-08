using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public string SesaId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string GenderId { get; set; }

        [ForeignKey("GenderId")]
        public Gender? Gender { get; set; }

        [Required]
        public string DepartmentCode { get; set; }

        [ForeignKey("DepartmentCode")]
        public Department? Department { get; set; }
    }
}
