using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using cs_antlr_Logical.Grammars;
using cs_antlr_Logical.States;

namespace cs_antlr_Logical.Visitors
{
    class ExpressionVisitor : LogicalGrammarBaseVisitor<LogicalOperation>
    {
        public Dictionary<string, LogicalVariable> Variables { get; set; } = new Dictionary<string, LogicalVariable>();
        public override LogicalOperation VisitParenthesis(LogicalGrammarParser.ParenthesisContext context) 
            => Goto(context, 0);

        public override LogicalOperation VisitMultiplication(LogicalGrammarParser.MultiplicationContext context) 
            => EffectuateBinaryOperation(context, (left, right) => new LogicalAnd(left, right));

        public override LogicalOperation VisitAddition(LogicalGrammarParser.AdditionContext context) 
            => EffectuateBinaryOperation(context, (left, right) => new LogicalOr(left, right));

        public override LogicalOperation VisitIdentifier(LogicalGrammarParser.IdentifierContext context)
        {
            string id = context.GetText();
            if (Variables.ContainsKey(id))
                return new LogicalVariableUsage(Variables[id]);
            var variable = new LogicalVariable(id);
            Variables.Add(id, variable);
            return new LogicalVariableUsage(variable);
        }

        public override LogicalOperation VisitConstant(LogicalGrammarParser.ConstantContext context) 
            => new LogicalConstant(context.GetText());

        public override LogicalOperation VisitInverse(LogicalGrammarParser.InverseContext context)
        {
            return EffectuateUnaryOperation(context, operation => new LogicalNot(operation));
        }

        private LogicalOperation EffectuateUnaryOperation(ParserRuleContext context,
            Func<LogicalOperation, LogicalOperation> callback) => callback(Goto(context, 0));

        private LogicalOperation EffectuateBinaryOperation(ParserRuleContext context,
            Func<LogicalOperation, LogicalOperation, LogicalOperation> callback)
        {
            var walker = Walker(context);
            return callback(walker(0), walker(1));
        }

        private Func<int, LogicalOperation> Walker(ParserRuleContext context) =>
            i => Goto(context, i);

        private LogicalOperation Goto(ParserRuleContext context, int i) => 
            Visit(context.GetRuleContext<LogicalGrammarParser.ExpressionContext>(i));
    }
}
