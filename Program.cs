using System;
using TMAPi_Simulator.Handlers;
using TMAPi_Simulator.Services;

namespace TMAPi_Simulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var taskService = new TaskService();
            var handler = new CommandHandler(taskService);

            Console.WriteLine("==========================================");
            Console.WriteLine("   Task Management API Simulator (TMAPi)");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            PrintHelp();

            while (true)
            {
                Console.Write("\nTMAPi> ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                string command = input.Trim();

                if (command.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (command.Equals("HELP", StringComparison.OrdinalIgnoreCase))
                {
                    PrintHelp();
                    continue;
                }

                string result = handler.ParseAndExecute(command);
                Console.WriteLine();
                Console.WriteLine(result);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
            Console.WriteLine("  GET /tasks                  - List all tasks");
            Console.WriteLine("  GET /tasks/{id}             - Get task by ID");
            Console.WriteLine();
            Console.WriteLine("  POST /tasks {json}          - Create a new task");
            Console.WriteLine("  PUT /tasks/{id} {json}      - Update an existing task");
            Console.WriteLine("  DELETE /tasks/{id}          - Delete a task");
            Console.WriteLine();
            Console.WriteLine("  HELP                        - Show this help text");
            Console.WriteLine("  EXIT                        - Quit the program");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine();
            Console.WriteLine("  POST /tasks {\"title\":\"Buy groceries\",\"description\":\"Milk and eggs\",\"priority\":\"High\"}");
            Console.WriteLine("  GET /tasks");
            Console.WriteLine("  GET /tasks/1");
            Console.WriteLine("  PUT /tasks/1 {\"status\":\"InProgress\",\"priority\":\"Low\"}");
            Console.WriteLine("  DELETE /tasks/1");
            Console.WriteLine();
        }
    }
}


