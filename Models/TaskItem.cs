using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TaskStatus = TMAPi_Simulator.Models.TaskStatus;

namespace TMAPi_Simulator.Models
{
    public class TaskItem(int id, string title, string description, Priority priority)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public Priority Priority { get; set; } = priority;
        public int? AssignedToUserId { get; set; } = null;
        public int? ProjectId { get; set; } = null;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
    }
}
