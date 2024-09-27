using Microsoft.EntityFrameworkCore;
using TaskManagerCourse.Api.Models;

namespace TaskManagerCourse.Api.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectAdmin> ProjectAdmins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();
            if (Users.Any(u => u.Status == UserStatus.Admin) == false)
            {
                var admin = new User("Anton", "Korotenko", "admin", "qwerty", UserStatus.Admin);
                Users.Add(admin);
                SaveChanges();
            }
        }
    }
}
