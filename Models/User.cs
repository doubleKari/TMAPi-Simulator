using System;
using System.Collections.Generic;
using System.Text;

namespace TMAPi_Simulator.Models
{
    public class User(string name, string email)
    {
        private static int counter = 0;
        public int Id { get; set; } = GetNextId();
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;

        private static int GetNextId()
        {
            return ++counter;
        }
    }
}
