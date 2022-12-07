using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ConsoleApp.Shared
{
    public abstract class BaseTask
    {
        public string[] GetInput(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
