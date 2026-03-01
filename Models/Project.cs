using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.Models
{
    public class Project(string name, string description)
    {
        private static int counter = 0;
        public int Id { get; set; } = GetNextId();
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public DateTime CreatedAt = DateTime.Now;

        private static int GetNextId()
        {
            return ++counter;
        }
    }
}
