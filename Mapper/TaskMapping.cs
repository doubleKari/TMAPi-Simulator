using System;
using System.Collections.Generic;
using System.Text;
using TMAPi_Simulator.DTOs;
using TMAPi_Simulator.Models;

namespace TMAPi_Simulator.Mapper
{
    public static class TaskMapping
    {
        public static TaskResponse ToResponse(this TaskItem taskItem)
        {
            return new TaskResponse(
                taskItem.Id,
                taskItem.Title,
                taskItem.Description,
                taskItem.Status.ToString(),
                taskItem.Priority.ToString(),
                taskItem.AssignedToUserId,
                taskItem.ProjectId,
                taskItem.CreatedDate,
                taskItem.DueDate
             );
        
        }
    }
}
