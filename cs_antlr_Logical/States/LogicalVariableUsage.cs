using System;
using System.Collections.Generic;

namespace cs_antlr_Logical.States
{
    public class LogicalVariableUsage : LogicalOperation
    {
        // Reference to the represented variable
        public LogicalVariable Variable { get; set; }

        public LogicalVariableUsage(LogicalVariable variable)
        {
            Variable = variable;
        }

        public override bool GetValue()
        {
            return Variable.Value;
        }
    }

    public class LogicalVariable
    {
        public string ID { get; set; } = "";
        public bool Value { get; set; } = false;

        public List<LogicalVariableUsage> Usages = new List<LogicalVariableUsage>();

        public LogicalVariable(string id = "")
        {
            ID = id;
        }
    }
}