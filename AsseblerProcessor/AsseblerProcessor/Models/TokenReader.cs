using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsseblerProcessor.Models
{
    class TokenReader
    {
        private List<string> storedInstructions = new List<string>();
        private List<string> currentInstruction = new List<string>();
        private bool rotate = false;
        private string[] blankString = { "" };

        public void Store(string[] tokens)
        {
            rotate = false;
            currentInstruction = new List<string>();
            foreach(string token in tokens)
            {
                CheckIfBranch(token);
                CheckIfDataProc(token);
                CheckIfLoadStore(token);
                checkIfRegister(token);
                checkIfValue(token);
            }
            storedInstructions.Add(EncodeInstruction(currentInstruction));
        }

        private string EncodeInstruction(List<string> Instruction)
        {
            string encoded = "";
            if (rotate)
            {
                string fourHex = Instruction[3];
                string fiveHex = Instruction[4];
                Instruction[3] = fiveHex;
                Instruction[4] = fourHex;
            }

            for(int j = 0; j < currentInstruction.Count; j++)
            {
                if (j % 2 == 0)
                {
                    encoded += Instruction[j];
                }
                else
                {
                    encoded += Instruction[j] + " ";
                }
            }

            string flipped = "";
            for(int j = encoded.Length - 1; j >= 0; j--)
            {
                flipped += encoded[j];
            }

            return Flip(flipped);
        }

        private string Flip(string flippedInstruction)
        {
            string[] groups = flippedInstruction.Split(' ');
            string[] totalGroups = new string[groups.Length];
            int ci = 0;
            for(int j = groups.Length-1; j >= 0; j--)
            {
                totalGroups[ci] = groups[j];
                ci++;
            }

            string encoded = "";
            for(int j = 0; j < totalGroups.Length; j++)
            {
                encoded += totalGroups[j] + " ";
            }
            return encoded;
        }

        private void checkIfRegister(string token)
        {
            string lowertoken = token.ToLower();
            if(lowertoken.Contains("r"))
            {
                if(lowertoken.Contains("ldr"))
                {
                    //do nothing
                }
                else if(lowertoken.Contains("str"))
                {
                    //do nothing
                }
                else if(lowertoken.Contains("or"))
                {
                    //do nothing
                }
                else
                {
                    appendInstruction(lowertoken[1] + "");
                }
            }
        }

        private void checkIfValue(string token)
        {
            string lowertoken = token.ToLower();
            if (lowertoken.Contains("0x"))
            {
                string[] instructions = lowertoken.Split('x');
                string value = instructions[1];
                char[] hexValues = value.ToArray();//so is this one
                foreach(var sHex in hexValues)
                {
                    int hexVal = Convert.ToInt32(sHex);
                    string hexOut = String.Format("{0:X}", value);
                    appendInstruction(hexOut);
                }
            }
        }

        private void CheckIfLoadStore(string token)
        {
            string lowertoken = token.ToLower();
            if (lowertoken.Contains("ldr"))
            {
                appendInstruction("E");
                appendInstruction("4");
                appendInstruction("1");
                rotate = true;
            }
            else if(lowertoken.Contains("str"))
            {
                appendInstruction("E");
                appendInstruction("4");
                appendInstruction("0");
                rotate = true;
            }
        }

        private void CheckIfDataProc(string token)
        {
            string lowertoken = token.ToLower();
            if (lowertoken.Contains("add"))
            {
                appendInstruction("E");
                appendInstruction("2");
                appendInstruction("8");
                rotate = true;
            }
            else if (lowertoken.Contains("sub"))
            {
                if (lowertoken.Contains("subi"))
                {
                    appendInstruction("E");
                    appendInstruction("2");
                    appendInstruction("4");
                    appendInstruction("6");
                }
                else
                {
                    appendInstruction("E");
                    appendInstruction("2");
                    appendInstruction("4");
                }
                rotate = true;
            }
            else if(lowertoken.Contains("tst"))
            {
                appendInstruction("E");
                appendInstruction("3");
                appendInstruction("0");
            }
            else if(lowertoken.Contains("cmp"))
            {
                if (lowertoken.Contains("cmpi"))
                {
                    appendInstruction("E");
                    appendInstruction("3");
                    appendInstruction("5");
                }
                else
                {
                    appendInstruction("E");
                    appendInstruction("3");
                    appendInstruction("4");
                    rotate = true;
                }
            }
            else if(lowertoken.Contains("movw"))
            {
                appendInstruction("E");
                appendInstruction("3");
                appendInstruction("A");
                rotate = true;
            }
            else if(lowertoken.Contains("movt"))
            {
                appendInstruction("E");
                appendInstruction("3");
                appendInstruction("4");
                rotate = true;
            }
            else if(lowertoken.Contains("or"))
            {
                appendInstruction("E");
                appendInstruction("3");
                appendInstruction("8");
                rotate = true;
            }
        }

        private void CheckIfBranch(string token)
        {
            string lowertoken = token.ToLower();
            if (lowertoken.Contains("bnc"))
            {
                appendInstruction("E");
                appendInstruction("A");
            }
            else if (lowertoken.Contains("bne"))
            {
                appendInstruction("1");
                appendInstruction("A");
            }
        }

        private void appendInstruction(string instruction)
        {
            currentInstruction.Add(instruction);
        }

        public void ShowInstructions()
        {
            foreach(var instruction in storedInstructions)
		    {
                Console.WriteLine(instruction);
		    }
        }

        public void CreateKernel()
        {
            throw new NotImplementedException();
        }
    }
}
