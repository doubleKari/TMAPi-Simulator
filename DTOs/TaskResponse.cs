using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.DTOs
{
    public record TaskResponse(
        int Id, 
        string Title, 
        string Description, 
        string Status, 
        string Priority, 
        int AssignedToUserId, 
        int ProjectId, 
        DateTime CreatedDate, 
        DateTime DueDate
    );
}
