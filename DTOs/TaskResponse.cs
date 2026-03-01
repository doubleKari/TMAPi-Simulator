using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        public string CreatedDateFormatted => CreatedDate.ToString("MMMM ddd, yyyy hh:mm");
        [JsonIgnore]
        public DateTime? DueDate { get; set; }
        public string? DueDateFormatted => DueDate?.ToString("MMMM ddd, yyyy hh:mm");

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }


    };
}
  