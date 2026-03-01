using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.DTOs
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public int? AssignedToUserId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
    };
}
  