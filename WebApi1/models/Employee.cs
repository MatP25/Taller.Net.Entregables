namespace WebApi1.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public Employee() { }

        public Employee(long id, string? name)
        {
            Id = id;
            Name = name;
        }
    }   
}