using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_antlr_Logical.States;

namespace cs_antlr_Logical
{
    public class LogicalGrammarResult
    {
        public LogicalOperation LogicalOperation { get; set; }
        public Dictionary<string, LogicalVariable> Variables { get; set; }

        public LogicalGrammarResult(LogicalOperation logicalOperation, Dictionary<string, LogicalVariable> variables)
        {
            LogicalOperation = logicalOperation;
            Variables = variables;
        }
    }
}
