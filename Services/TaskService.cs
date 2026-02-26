using System;
using System.Collections.Generic;
using System.Text;
using TMAPi_Simulator.DTOs;
using TMAPi_Simulator.Models;

namespace TMAPi_Simulator.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks;
        private readonly int _nextId = 1;

        public TaskService()
        {
            _tasks = [];
            _nextId = 1;
        }

        public ApiResponse<TaskResponse> CreateTask(CreateTaskRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                //parse priority string to priority enum

            }
        }

        

    }
}
