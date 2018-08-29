using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models
{
    public class AssemblyMachine
    {
        public List<String> instructions { get; set; } = new List<string>();

        public void addInstruction(string line)
        {
            instructions.Add(line); 
        }
    }
}
