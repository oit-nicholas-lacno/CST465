using FinalProject.Models;
using FinalProject.DataObjects;
using Task = FinalProject.DataObjects.Task;

namespace FinalProject
{
    public static class CustomExtensionMethods
    {
        public static TaskModel ToModel(this Task task)
        {
            TaskModel model = new();
            model.Name = task.Name;
            model.Description = task.Description;
            model.DueDate = task.Due;
            model.TaskStatus = task.TaskStatus.ToString();

            return model;
        }

        public static Task ToDataObject(this TaskModel model)
        {
            Task task = new();
            task.Name = model.Name;
            task.Description = model.Description;
            task.Due = model.DueDate;
            switch (model.TaskStatus)
            {
                case "NotStarted":
                    task.TaskStatus = Status.NotStarted;
                    break;
                case "Started":
                    task.TaskStatus = Status.Started;
                    break;
                case "Completed":
                    task.TaskStatus = Status.Completed;
                    break;
            }
            return task;
        }

        public static PlannerModel ToModel(this Planner planner)
        {
            PlannerModel model = new();
            model.TimeZone = TimeZoneInfo.Local;
            foreach (Task t in planner.Tasks)
            {
                var tmodel = t.ToModel();
                tmodel.DueDate = TimeZoneInfo.ConvertTimeFromUtc(t.Due, model.TimeZone);
                model.Tasks.Add(tmodel);
            }
            return model;
        }

        public static Planner ToDataObject(this PlannerModel model)
        {
            Planner planner = new();
            foreach (TaskModel tm in model.Tasks)
            {
                Task t = tm.ToDataObject();
                t.Due = TimeZoneInfo.ConvertTimeToUtc(tm.DueDate, model.TimeZone);
                if (t.TaskStatus != Status.Completed)
                    planner.Tasks.Add(t);
            }
            return planner;
        }
    }
}
