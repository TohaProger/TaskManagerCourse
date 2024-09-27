namespace TaskManagerCourse.Api.Models
{
    public class ProjectAdmin
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public ProjectAdmin(User user)
        {
            UserId = user.Id;
            User = user;
        }
    }
}
