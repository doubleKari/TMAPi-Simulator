using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.Models
{
    public class Project(int id, string name, string description)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public DateTime CreatedAt = DateTime.Now;
    }
}
