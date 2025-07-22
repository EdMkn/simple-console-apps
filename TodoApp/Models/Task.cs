
namespace TodoApp.Models
{

    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
    }
}