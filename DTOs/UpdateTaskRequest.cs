using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.DTOs
{
    public record UpdateTaskRequest(
        string Title, 
        string Description, 
        string Status, 
        string Priority, 
        int AssignedToUserId, 
        DateTime DueDate
    );
}
