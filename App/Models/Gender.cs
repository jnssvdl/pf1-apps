using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Gender
    {
        [Key]
        public string GenderId  { get; set; }

        [Required]
        public string GenderName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
