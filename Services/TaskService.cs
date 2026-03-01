using System;
using System.Collections.Generic;
using System.Text;
using TMAPi_Simulator.DTOs;
using TMAPi_Simulator.Utils;
using TMAPi_Simulator.Models;
using TaskStatus = TMAPi_Simulator.Models.TaskStatus;

namespace TMAPi_Simulator.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks;
        public TaskService()
        {
            _tasks = [];
        }

        public ApiResponse<TaskResponse> CreateTask(CreateTaskRequest request)
        {
            if (request == null)
            {
                return ApiResponse<TaskResponse>.ErrorResponse("Request cannot be null.", 400);
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return ApiResponse<TaskResponse>.ErrorResponse("Title is required.", 400);
            }

            if (!Enum.TryParse(request.Priority, true, out Priority priority))
            {
                return ApiResponse<TaskResponse>.ErrorResponse("Invalid priority value.", 400);
            }

            var task = new TaskItem(request.Title, request.Description, priority)
            {
                AssignedToUserId = request.AssignedToUserId,
                ProjectId = request.ProjectId,
                CreatedDate = DateTime.UtcNow,
                DueDate = request.DueDate,
                Status = TaskStatus.Todo
            };

            _tasks.Add(task);

            var response = task.ToResponse();

            return ApiResponse<TaskResponse>.SuccessResponse(response, $"Task {response.Id} created successfully.");
        }
        public ApiResponse<List<TaskResponse>> GetAllTasks()
        {
            List<TaskResponse> tasks = [];
            foreach (var t in _tasks)
            {
                tasks.Add(t.ToResponse()); 
            }
            return ApiResponse<List<TaskResponse>>.SuccessResponse(tasks, "Sucess");
        }

        public ApiResponse<TaskResponse> GetTaskById(int id)
        {
            var task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return ApiResponse<TaskResponse>.ErrorResponse($"Task with ID: {id} not found!", 404);
            }

            TaskResponse data = task.ToResponse();
            return ApiResponse<TaskResponse>.SuccessResponse(data, "Success");
        }
            
        
    }
}
