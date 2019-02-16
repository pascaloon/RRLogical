using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs_antlr_Logical;
using cs_antlr_Logical.States;

namespace cs_LogicalAnalyzer
{
    public class Analyzer
    {
        private LogicalGrammarAnalyzer _grammarAnalyzer;

        public Analyzer(string equation)
        {
            _grammarAnalyzer = new LogicalGrammarAnalyzer(equation);
        }

        public LogicalReport Analyze()
        {
            LogicalGrammarResult result = _grammarAnalyzer.Analyze();
            return LogicalReport.CreateFromResults(result);
        }
    }
}
