using System;
using System.Text;
using System.Text.Json;
using TMAPi_Simulator.Services;
using TMAPi_Simulator.DTOs;

namespace TMAPi_Simulator.Handlers
{
    public class CommandHandler(TaskService taskService)
    {
        public string ParseAndExecute(string command)
        {
            // Trim whitespace
            command = command.Trim();

            // Split into parts: method and rest
            var parts = command.Split(' ', 2);

            if (parts.Length < 2)
            {
                return "Invalid command format. Use: METHOD /path [json-data]\nType HELP for available commands.";
            }

            string method = parts[0].ToUpper();
            string rest = parts[1].Trim();

            try
            {
                return method switch
                {
                    "GET" => HandleGet(rest),
                    "POST" => HandlePost(command),
                    "PUT" => HandlePut(command),
                    "DELETE" => HandleDelete(rest),
                    _ => $"Unknown HTTP method: {method}\nSupported methods: GET, POST, PUT, DELETE",
                };
            }
            catch (Exception ex)
            {
                return $"Error executing command: {ex.Message}";
            }
        }

        #region GET Handlers

        private string HandleGet(string path)
        {
            // GET /tasks
            if (path == "/tasks")
            {
                return HandleGetAllTasks();
            }

            // GET /tasks/{id}
            if (path.StartsWith("/tasks/"))
            {
                string idPart = path["/tasks/".Length..];

                if (int.TryParse(idPart, out int id))
                {
                    return HandleGetTaskById(id);
                }
                else
                {
                    return "Invalid task ID format. ID must be a number.";
                }
            }

            return $"Unknown GET endpoint: {path}";
        }

        private string HandleGetAllTasks()
        {
            var response = taskService.GetAllTasks();

            StringBuilder sb = new();
            sb.AppendLine($"Status: {response.StatusCode}");
            sb.AppendLine($"Message: {response.Message}");
            sb.AppendLine();

            if (response.Success && response.Data != null)
            {
                if (response.Data.Count == 0)
                {
                    sb.AppendLine("No tasks found.");
                }
                else
                {
                    sb.AppendLine($"Total Tasks: {response.Data.Count}");
                    sb.AppendLine(new string('-', 80));

                    foreach (var task in response.Data)
                    {
                        sb.AppendLine(FormatTask(task));
                        sb.AppendLine(new string('-', 80));
                    }
                }
            }

            return sb.ToString();
        }

        private string HandleGetTaskById(int id)
        {
            var response = taskService.GetTaskById(id);

            StringBuilder sb = new();
            sb.AppendLine($"Status: {response.StatusCode}");
            sb.AppendLine($"Message: {response.Message}");
            sb.AppendLine();

            if (response.Success && response.Data != null)
            {
                sb.AppendLine("Task Details:");
                sb.AppendLine(new string('-', 80));
                sb.AppendLine(FormatTask(response.Data));
            }

            return sb.ToString();
        }

        #endregion

        #region POST Handlers

        private string HandlePost(string command)
        {
            // Find where JSON starts
            int jsonStart = command.IndexOf('{');

            if (jsonStart == -1)
            {
                return "POST request requires JSON data.\nFormat: POST /path {\"property\":\"value\"}";
            }

            // Extract path (between POST and {)
            string pathPart = command[..jsonStart].Trim();
            var pathParts = pathPart.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                return "Invalid POST format. Use: POST /path {json}";
            }

            string path = pathParts[1];

            // Extract JSON data
            string jsonData = command[jsonStart..].Trim();

            // POST /tasks
            if (path == "/tasks")
            {
                return HandleCreateTask(jsonData);
            }

            return $"Unknown POST endpoint: {path}";
        }

        private string HandleCreateTask(string jsonData)
        {
            try
            {
                var request = JsonSerializer.Deserialize<CreateTaskRequest>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (request == null)
                {
                    return "Failed to parse JSON data.";
                }

                var response = taskService.CreateTask(request);

                StringBuilder sb = new();
                sb.AppendLine($"Status: {response.StatusCode}");
                sb.AppendLine($"Message: {response.Message}");
                sb.AppendLine();

                if (response.Success && response.Data != null)
                {
                    sb.AppendLine("Created Task:");
                    sb.AppendLine(new string('-', 80));
                    sb.AppendLine(FormatTask(response.Data));
                }

                return sb.ToString();
            }
            catch (JsonException ex)
            {
                return $"Invalid JSON format: {ex.Message}\n\nExample:\nPOST /tasks {{\"title\":\"Task Name\",\"description\":\"Details\",\"priority\":\"High\"}}";
            }
        }

        #endregion

        #region PUT Handlers

        private string HandlePut(string command)
        {
            // Find where JSON starts
            int jsonStart = command.IndexOf('{');

            if (jsonStart == -1)
            {
                return "PUT request requires JSON data.\nFormat: PUT /path {\"property\":\"value\"}";
            }

            // Extract path (between PUT and {)
            string pathPart = command[..jsonStart].Trim();
            var pathParts = pathPart.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                return "Invalid PUT format. Use: PUT /path {json}";
            }

            string path = pathParts[1];

            // Extract JSON data
            string jsonData = command.Substring(jsonStart).Trim();

            // PUT /tasks/{id}
            if (path.StartsWith("/tasks/"))
            {
                string idPart = path.Substring("/tasks/".Length);

                if (int.TryParse(idPart, out int id))
                {
                    return HandleUpdateTask(id, jsonData);
                }
                else
                {
                    return "Invalid task ID format. ID must be a number.";
                }
            }

            return $"Unknown PUT endpoint: {path}";
        }

        private string HandleUpdateTask(int id, string jsonData)
        {
            try
            {
                var request = JsonSerializer.Deserialize<UpdateTaskRequest>(jsonData, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (request == null)
                {
                    return "Failed to parse JSON data.";
                }

                var response = taskService.UpdateTaskById(id, request);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Status: {response.StatusCode}");
                sb.AppendLine($"Message: {response.Message}");
                sb.AppendLine();

                if (response.Success && response.Data != null)
                {
                    sb.AppendLine("Updated Task:");
                    sb.AppendLine(new string('-', 80));
                    sb.AppendLine(FormatTask(response.Data));
                }

                return sb.ToString();
            }
            catch (JsonException ex)
            {
                return $"Invalid JSON format: {ex.Message}\n\nExample:\nPUT /tasks/1 {{\"status\":\"InProgress\",\"priority\":\"High\"}}";
            }
        }

        #endregion

        #region DELETE Handlers

        private string HandleDelete(string path)
        {
            // DELETE /tasks/{id}
            if (path.StartsWith("/tasks/"))
            {
                string idPart = path["/tasks/".Length..];

                if (int.TryParse(idPart, out int id))
                {
                    return HandleDeleteTask(id);
                }
                else
                {
                    return "Invalid task ID format. ID must be a number.";
                }
            }

            return $"Unknown DELETE endpoint: {path}";
        }

        private string HandleDeleteTask(int id)
        {
            var response = taskService.DeleteTask(id);

            StringBuilder sb = new();
            sb.AppendLine($"Status: {response.StatusCode}");
            sb.AppendLine($"Message: {response.Message}");
            sb.AppendLine();

            if (response.Success)
            {
                sb.AppendLine($"Task #{id} has been deleted successfully.");
            }

            return sb.ToString();
        }

        #endregion

        #region Helper Methods

        private static string FormatTask(TaskResponse task)
        {
            StringBuilder sb = new();

            sb.AppendLine($"ID:           {task.Id}");
            sb.AppendLine($"Title:        {task.Title}");
            sb.AppendLine($"Description:  {task.Description ?? "N/A"}");
            sb.AppendLine($"Status:       {task.Status}");
            sb.AppendLine($"Priority:     {task.Priority}");
            sb.AppendLine($"Assigned To:  {(task.AssignedToUserId.HasValue ? $"User #{task.AssignedToUserId.Value}" : "Unassigned")}");
            sb.AppendLine($"Project:      {(task.ProjectId.HasValue ? $"Project #{task.ProjectId.Value}" : "No Project")}");
            sb.AppendLine($"Created:      {task.CreatedDateFormatted}");
            sb.AppendLine($"Due Date:     {(task.DueDateFormatted ?? "Not Set")}");

            return sb.ToString();
        }

        #endregion
    }
}
