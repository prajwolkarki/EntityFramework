using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models
{
    public class Student
    {
        
        [Key]
        public int Id { get; set; }

        [Column("StudentName",TypeName ="varchar(15)")]
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }

        [Column("StudentGender", TypeName = "varchar(10)")]
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Standard { get; set;}
    }
}
