using MagniFinance.Models;
using Microsoft.EntityFrameworkCore;


namespace MagniFinance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<College> college { get; set; }
        public DbSet<Courses> course { get; set; }
        public DbSet<Subjects> subject { get; set; }
        public DbSet<Students> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Grades> grade { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<College>()
                .HasMany(ur => ur.courses);

            builder.Entity<Subjects>()
               .HasOne(ur => ur.teacher);

            builder.Entity<Courses>()
              .HasMany(ur => ur.subjects);

            builder.Entity<Students>()
               .HasMany<Subjects>(s => s.subjects)
               .WithMany(c => c.students);
               
             


        }


    }
}
