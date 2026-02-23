# Task Management API Simulator

A console-based application that simulates a RESTful API for task management. This project demonstrates core backend development concepts including CRUD operations, service layer architecture, data persistence, and async programming - all implemented in a console environment.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies & Concepts](#technologies--concepts)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [API Commands](#api-commands)
- [Development](#development)


## 🎯 Overview

This project simulates how a REST API works by accepting text-based commands that mimic HTTP requests. It's designed as a learning project to practice C# fundamentals and backend development patterns before moving to ASP.NET Core Web API development.

### Learning Objectives

- Practice object-oriented programming principles
- Implement CRUD operations with a service layer architecture
- Work with collections and LINQ for data manipulation
- Understand async/await patterns
- Implement data persistence with JSON serialization
- Learn API design principles and request/response patterns
- Practice collaborative development with Git/GitHub

## ✨ Features

### Core Features
- ✅ **Task Management**: Create, read, update, and delete tasks
- ✅ **Project Organization**: Group tasks into projects
- ✅ **User Assignment**: Assign tasks to different users
- ✅ **Status Workflow**: Manage task states (Todo, InProgress, Done, Cancelled)
- ✅ **Priority Levels**: Set task priorities (Low, Medium, High, Urgent)
- ✅ **Search & Filter**: Find tasks by status, priority, assignee, or keyword
- ✅ **Data Persistence**: Save and load data from JSON files
- ✅ **Async Operations**: Simulated asynchronous processing

### Advanced Features (Optional)
- 🔄 **Bulk Operations**: Create or update multiple tasks at once
- 📊 **Task Dependencies**: Define task relationships and blocking
- 📝 **Event Logging**: Track all operations with event-driven logging
- ✅ **Input Validation**: Comprehensive error handling and validation

## 🛠 Technologies & Concepts

### C# Language Features
- Classes, Records, Structs, and Enums
- Properties and Constructors
- Generic Types
- Nullable Types
- Pattern Matching
- LINQ Queries
- Delegates and Lambdas
- Async/Await
- Extension Methods

### Design Patterns & Principles
- Service Layer Pattern
- Data Transfer Objects (DTOs)
- Dependency Injection principles
- Separation of Concerns
- Repository Pattern concepts

### Technical Skills
- JSON Serialization/Deserialization
- File I/O Operations
- Exception Handling
- String Parsing and Manipulation
- Collections Management (List, Dictionary)

## 📁 Project Structure
```
TaskManagementAPI/
│
├── Models/                      # Domain entities
│   ├── TaskItem.cs              # Core task entity
│   ├── Project.cs               # Project entity
│   ├── User.cs                  # User entity
│   ├── TaskStatus.cs            # Task status enum
│   └── Priority.cs              # Priority level enum
│
├── DTOs/                        # Data Transfer Objects
│   ├── ApiResponse.cs           # Generic API response wrapper
│   ├── TaskResponse.cs          # Task response DTO
│   ├── CreateTaskRequest.cs     # Request DTO for creating tasks
│   └── UpdateTaskRequest.cs     # Request DTO for updating tasks
│
├── Services/                    # Business logic layer
│   ├── TaskService.cs           # Task management operations
│   ├── ProjectService.cs        # Project management operations
│   └── UserService.cs           # User management operations
│
├── Handlers/                    # Request handlers
│   └── CommandHandler.cs        # Parses and routes API commands
│
├── Data/                        # Data storage
│   ├── tasks.json               # Persisted tasks
│   ├── projects.json            # Persisted projects
│   └── users.json               # Persisted users
│
├── Program.cs                   # Application entry point
├── TaskManagementAPI.csproj     # Project configuration
└── README.md                    # This file
```

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
- A code editor (Visual Studio, VS Code, or Rider recommended)
- Git for version control

### Installation

1. **Clone the repository**
```bash
   git clone https://github.com/your-username/TaskManagementAPI.git
   cd TaskManagementAPI
```

2. **Restore dependencies**
```bash
   dotnet restore
```

3. **Build the project**
```bash
   dotnet build
```

4. **Run the application**
```bash
   dotnet run
```

### First Run

On first run, the application will:
- Create the `Data/` folder if it doesn't exist
- Initialize empty JSON files for data storage
- Display the command menu and await input

## 💻 Usage

### Starting the Application
```bash
cd TaskManagementAPI
dotnet run
```

### Command Interface

The application accepts text commands that simulate HTTP API requests:
```
=== Task Management API Simulator ===
Enter commands in the format: METHOD /endpoint {optional-json}
Type 'HELP' for available commands
Type 'EXIT' to quit

> _
```

### Example Workflow
```bash
# Create a user
> POST /users {"id":1,"name":"John Doe","email":"john@example.com"}

# Create a project
> POST /projects {"id":1,"name":"Mobile App","description":"New mobile application"}

# Create a task
> POST /tasks {"title":"Design login screen","description":"Create mockups","priority":"High","assignedToUserId":1,"projectId":1}

# View all tasks
> GET /tasks

# Update task status
> PUT /tasks/1 {"status":"InProgress"}

# Search tasks
> GET /tasks?search=login

# Filter by status
> GET /tasks?status=InProgress

# Get project tasks
> GET /projects/1/tasks

# Delete a task
> DELETE /tasks/1
```

## 📚 API Commands

### Task Endpoints

| Command | Description | Example |
|---------|-------------|---------|
| `POST /tasks {json}` | Create a new task | `POST /tasks {"title":"Fix bug","description":"Login issue","priority":"High"}` |
| `GET /tasks` | Get all tasks | `GET /tasks` |
| `GET /tasks/{id}` | Get task by ID | `GET /tasks/1` |
| `PUT /tasks/{id} {json}` | Update a task | `PUT /tasks/1 {"status":"Done"}` |
| `DELETE /tasks/{id}` | Delete a task | `DELETE /tasks/1` |
| `GET /tasks?status={status}` | Filter by status | `GET /tasks?status=InProgress` |
| `GET /tasks?priority={priority}` | Filter by priority | `GET /tasks?priority=High` |
| `GET /tasks?assignedTo={userId}` | Filter by assignee | `GET /tasks?assignedTo=1` |
| `GET /tasks?search={keyword}` | Search tasks | `GET /tasks?search=bug` |

### User Endpoints

| Command | Description | Example |
|---------|-------------|---------|
| `POST /users {json}` | Create a new user | `POST /users {"id":1,"name":"Jane","email":"jane@example.com"}` |
| `GET /users` | Get all users | `GET /users` |
| `GET /users/{id}` | Get user by ID | `GET /users/1` |

### Project Endpoints

| Command | Description | Example |
|---------|-------------|---------|
| `POST /projects {json}` | Create a new project | `POST /projects {"id":1,"name":"Website","description":"Company site"}` |
| `GET /projects` | Get all projects | `GET /projects` |
| `GET /projects/{id}` | Get project by ID | `GET /projects/1` |
| `GET /projects/{id}/tasks` | Get tasks in project | `GET /projects/1/tasks` |

### Request Body Examples

#### Create Task Request
```json
{
  "title": "Implement user authentication",
  "description": "Add JWT-based authentication to the API",
  "priority": "High",
  "assignedToUserId": 1,
  "projectId": 1,
  "dueDate": "2024-12-31"
}
```

#### Update Task Request
```json
{
  "title": "Updated title (optional)",
  "description": "Updated description (optional)",
  "status": "InProgress",
  "priority": "Urgent",
  "assignedToUserId": 2,
  "dueDate": "2024-11-30"
}
```

### Status Codes

The API returns status codes similar to HTTP:
- `200` - Success
- `201` - Created
- `404` - Not Found
- `400` - Bad Request
- `500` - Internal Server Error

## 🔧 Development

### Branch Strategy

We follow a feature branch workflow:
```bash
# Create a new feature branch
git checkout -b feature/TM-XXX

# Make your changes and commit
git add .
git commit -m "TM-XXX: Description of changes"

# Push to GitHub
git push origin feature/TM-XXX-brief-description

# Create a Pull Request on GitHub
```

### Commit Message Format
```
[TM-XXX] Brief description of change

Optional longer description explaining:
- What was changed
- Why it was changed
- Any important implementation details
```

Examples:
```
TM-001: Create TaskStatus and Priority enums
TM-009: Implement CreateTask method with validation
TM-015: Add POST command parsing for task creation
```

## 📈 Project Milestones

- [x] **Milestone 1**: Foundation & Core Models
- [x] **Milestone 2**: API Response Structure
- [x] **Milestone 3**: Task Service Layer
- [x] **Milestone 4**: Command Handler & Parsing
- [x] **Milestone 5**: Filtering & Search
- [x] **Milestone 6**: User & Project Management
- [ ] **Milestone 7**: Async Operations *(Optional)*
- [ ] **Milestone 8**: Data Persistence

## 🙏 Acknowledgments

- Inspired by real-world task management systems (Jira, Trello, Asana)
- Built as a learning project for ASP.NET Core preparation
- Thanks to the C# and .NET community for excellent documentation
  
---

**Happy Coding! 🚀**

*Built with ❤️ using C# and .NET*
