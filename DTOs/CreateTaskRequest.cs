using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.DTOs
{
    public record CreateTaskRequest (
        string Title, 
        string Description, 
        string Priority, 
        int? AssignedToUserId, 
        int? ProjectId, 
        DateTime? DueDate 
    );
    
}
