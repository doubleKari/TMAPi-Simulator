using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using TaskStatus = TMAPi_Simulator.Models.TaskStatus;

namespace TMAPi_Simulator.Models
{
    public class TaskItem
    {
        private static int counter = 0;

        public TaskItem(string title, string description, Priority priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
        }
        public int Id { get; set; } = GetNextId();
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public Priority Priority { get; set; }
        public int? AssignedToUserId { get; set; } = null;
        public int? ProjectId { get; set; } = null;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }

        private static int GetNextId()
        {
            return ++counter;
        }
    }
}
