using Microsoft.EntityFrameworkCore;
using TaskManagerCourse.Api.Models;
using TaskManagerCourse.Common.Models;

namespace TaskManagerCourse.Api.Data
{
    public class MyDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectAdmin> ProjectAdmins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
            Database.EnsureCreated();
            if (Users.Any(u => u.Status == UserStatus.Admin) == false)
            {
                var admin = new User("Anton", "Korotenko", "email", "qwerty1234", "8910phone", UserStatus.Admin, null);
                Users.Add(admin);
                SaveChanges();
            }
        }
    }
}
