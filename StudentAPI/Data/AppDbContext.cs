using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com", Age = 20, Course = "Computer Science", EnrolledDate = DateTime.UtcNow },
            new Student { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", Age = 22, Course = "Mathematics", EnrolledDate = DateTime.UtcNow },
            new Student { Id = 3, FirstName = "Carol", LastName = "White", Email = "carol@example.com", Age = 21, Course = "Physics", EnrolledDate = DateTime.UtcNow }
        );
    }
}
