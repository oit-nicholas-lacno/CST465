namespace FinalProject.DataObjects
{
    public enum Status
    {
        NotStarted,
        Started,
        Completed
    }

    public class Task
    {
        public DateTime Due { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Status TaskStatus { get; set; }
    }
}
