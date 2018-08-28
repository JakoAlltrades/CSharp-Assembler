using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models.Tokens
{
    public class CondToken : Token
    {
        public List<string> possibleConditions { get; set; } = new List<string>();
        public string condition;

        public CondToken()
        {
            possibleConditions.Add("EQ");
            possibleConditions.Add("NE");
            possibleConditions.Add("LT");
            possibleConditions.Add("GT");
            possibleConditions.Add("GE");
            possibleConditions.Add("AL");
        }


        public override bool Process(string cond)
        {
            bool isCond = false;
            if (possibleConditions.Contains(cond))
            {
                condition = cond;
                isCond = true;
            }
            return isCond;
        }

    }
}
