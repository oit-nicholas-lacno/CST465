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
    }
}
