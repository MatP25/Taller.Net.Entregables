namespace WebApi1.Models
{
    public class Task
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? DurationHours { get; set; }
        public Employee? AssignedTo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Task() { }

        public Task(
            long id,
            string? name,
            string? description,
            int? durationHours = null,
            Employee? assignedTo = null)
        {
            Id = id;
            Description = description;
            Name = name;
            DurationHours = durationHours;
            AssignedTo = assignedTo;
        }
    }   
}