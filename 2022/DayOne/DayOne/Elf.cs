using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class Elf
    {
        int calories;
        string name;
        public Elf(string name) 
        { 
            this.name = name;
        }

        public int Calories
        {
            get { return calories; }
        }

        public string Name
        { 
            get { return name; } 
        }

        public void add(int calories)
        {
            this.calories += calories;
        }
    }
}
