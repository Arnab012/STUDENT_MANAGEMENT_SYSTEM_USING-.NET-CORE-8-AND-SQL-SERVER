using Microsoft.EntityFrameworkCore;

namespace Code_First_Approch.Models
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions options):base  (options)
        {

            
        }
        public DbSet<Student> Students { get; set; }

    }
}
