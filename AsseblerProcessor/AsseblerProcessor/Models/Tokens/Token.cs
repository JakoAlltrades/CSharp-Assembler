using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models.Tokens
{
    public abstract class Token
    {
        public abstract bool Process(string cond);
    }
}
