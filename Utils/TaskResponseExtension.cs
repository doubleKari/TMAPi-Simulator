using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TMAPi_Simulator.DTOs;

namespace TMAPi_Simulator.Utils
{
    public static class TaskResponseExtension
    {
        public static string ToJson(this TaskResponse task)
        {
            return JsonSerializer.Serialize(task, GetJsonOptions());

        }

        public static string ToJson(this List<TaskResponse> tasks)
        {
            return JsonSerializer.Serialize(tasks, GetJsonOptions());
        }

        public static string ToJson(this IEnumerable<TaskResponse> tasks)
        {
            return JsonSerializer.Serialize(tasks, GetJsonOptions());
        }


        private static JsonSerializerOptions GetJsonOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }
    }
}
