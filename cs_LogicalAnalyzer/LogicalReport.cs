using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_antlr_Logical;
using cs_antlr_Logical.States;

namespace cs_LogicalAnalyzer
{
    public class LogicalReport
    {
        internal static LogicalReport CreateFromResults(LogicalGrammarResult result)
        {
            LogicalReport report = new LogicalReport();
            if (result.Variables.Count == 0)
            {
                report.UniqueResult = result.LogicalOperation.GetValue();
                return report;
            }

            List<LogicalVariable> variablesList = result.Variables.Values.OrderBy(v => v.ID).ToList();
            report.ColumnNames = variablesList.Select(variable => variable.ID).ToList();
            report.PopulateFromVariables(result, variablesList);
            bool r1 = report.Rows[0].Result;
            if (report.Rows.All(row => row.Result == r1))
                report.UniqueResult = r1;

            return report;
        }

        private void PopulateFromVariables(LogicalGrammarResult result, List<LogicalVariable> variables, int i = 0)
        {
            if (i == variables.Count)
            {
                Rows.Add(LogicalRow.CreateFromVariablesValues(this, result, variables));
                return;
            }
            variables[i].Value = false;
            PopulateFromVariables(result, variables, i + 1);
            variables[i].Value = true;
            PopulateFromVariables(result, variables, i + 1);
        }

        public bool? UniqueResult { get; private set; } = null;
        
        public List<string> ColumnNames { get; private set; } = new List<string>();
        public List<LogicalRow> Rows { get; private set; } = new List<LogicalRow>();
    }

    public class LogicalRow
    {
        internal static LogicalRow CreateFromVariablesValues(LogicalReport report, LogicalGrammarResult result, List<LogicalVariable> variables)
        {
            var logicalRow = new LogicalRow(report);
            logicalRow.VariablesValues = variables.Select(variable => variable.Value).ToList();
            logicalRow.Result = result.LogicalOperation.GetValue();
            return logicalRow;

        }

        private LogicalReport _report;

        private LogicalRow(LogicalReport report)
        {
            _report = report;
        }

        
        public List<bool> VariablesValues { get; private set; } = new List<bool>();
        public bool Result { get; private set; } = false;
    }
}
