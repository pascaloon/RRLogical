using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using cs_antlr_Logical.Grammars;
using cs_antlr_Logical.States;
using cs_antlr_Logical.Visitors;

namespace cs_antlr_Logical
{
    public class LogicalGrammarAnalyzer
    {
        private string _equation;

        public LogicalGrammarAnalyzer(string equation)
        {
            _equation = equation;
        }

        public LogicalGrammarResult Analyze()
        {
            AntlrInputStream stream = new AntlrInputStream(new StringReader(_equation));

            var lexer = new LogicalGrammarLexer(stream);

            var tokens = new CommonTokenStream(lexer);
            var parser = new LogicalGrammarParser(tokens);
            var tree = parser.compileUnit();
            ExpressionVisitor visitor = new ExpressionVisitor();
            LogicalOperation result = visitor.Visit(tree);

            return new LogicalGrammarResult(result, visitor.Variables);

        }
    }
}
