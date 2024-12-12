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
        public int ID { get; set; }
        public DateTime Due { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Status TaskStatus { get; set; }

        public string ConvertTaskStatus()
        {
            switch (TaskStatus)
            {
                case Status.NotStarted:
                    return "Not Started";
                    
                case Status.Started:
                    return "Started";

                case Status.Completed:
                    return "Completed";

                default:
                    return "";
            }
        }
    }
}
