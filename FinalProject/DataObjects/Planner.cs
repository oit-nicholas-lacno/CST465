namespace FinalProject.DataObjects
{
    public class Planner
    {
        public List<Task> Tasks { get; set; } = new();

        public void AddTask(Task task)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Due > task.Due)
                {
                    Tasks.Insert(i, task);
                    return;
                }
            }
            Tasks.Add(task);
        }
    }
}
