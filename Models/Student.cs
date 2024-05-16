using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Approch.Models
{
    public class Student
    {
        [Key]
        public  int Id { get; set; }
        [Column("StudentName",TypeName ="varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("Gender", TypeName = "varchar(20)")]

        public string Gender { get; set; }
        public int Age{ get; set;}
        public string standered {  get; set; }
    }
}
