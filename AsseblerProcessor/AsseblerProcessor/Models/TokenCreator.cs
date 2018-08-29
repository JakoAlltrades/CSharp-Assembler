using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models
{
    class TokenCreator
    {
        public string[] Create(string instuction)
        {
            string[] tokens = instuction.Split(' ');
            return tokens;
        }
    }
}
