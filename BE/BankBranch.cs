using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        public uint BankNumber { get; set; }
        public string BankName { get; set; }
        public uint BranchNumber{ get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity;
        public override string ToString()
        {
            return BankName + " " + BankNumber + " " + BranchAddress + " " + BranchCity + " " + BranchNumber;
        }

    }
}
