using System;
using System.Collections.Generic;
using System.Text;
using TMAPi_Simulator.DTOs;
using TMAPi_Simulator.Models;

namespace TMAPi_Simulator.Utils
{
    public static class TaskMapping
    {
        public static TaskResponse ToResponse(this TaskItem taskItem)
        {
            return new TaskResponse()
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                Status = taskItem.Status.ToString(),
                Priority = taskItem.Priority.ToString(),
                AssignedToUserId = taskItem.AssignedToUserId,
                ProjectId = taskItem.ProjectId,
                CreatedDate = taskItem.CreatedDate,
                DueDate = taskItem.DueDate
            };
        
        }
    }
}
