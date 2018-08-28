using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models.Tokens
{
    public class OperationToken : Token
    {
        public List<string> possibleOperations { get; set; }
        public string operation { get; set; }
        public OperationToken()
        {
            possibleOperations.Add("branch");
            possibleOperations.Add("dataProc");
            possibleOperations.Add("LdrStr");
        }


        public override bool Process(string cond)
        {
            bool isCond = false;
            if (possibleOperations.Contains(cond))
            {
                operation = cond;
                isCond = true;
            }
            return isCond;
        }
    }
}
