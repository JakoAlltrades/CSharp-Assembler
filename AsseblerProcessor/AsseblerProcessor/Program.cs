using AsseblerProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AssemblyMachine am = new AssemblyMachine();
            TokenCreator tc = new TokenCreator();
            TokenReader tr = new TokenReader();
            string path = Path.GetFullPath("Instructions.txt");

            var sr = new StreamReader(path);
            string line;
            while((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                am.addInstruction(line);
            }

            List<string> instructions = am.instructions;

            foreach(var instuction in instructions)
            {
                String[] tokens = tc.Create(instuction);
                tr.Store(tokens);
            }
            tr.ShowInstructions();
            //tr.CreateKernel();
        }
    }
}
