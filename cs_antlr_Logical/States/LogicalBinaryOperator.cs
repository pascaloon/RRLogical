namespace cs_antlr_Logical.States
{
    abstract class LogicalBinaryOperator : LogicalOperation
    {
        public LogicalOperation Left { get; protected set; }
        public LogicalOperation Right { get; protected set; }

        public LogicalBinaryOperator(LogicalOperation left, LogicalOperation right)
        {
            Left = left;
            Right = right;
        }

        public override bool GetValue() => Operation(Left, Right);
        protected abstract bool Operation(LogicalOperation left, LogicalOperation right);

    }

    class LogicalOr : LogicalBinaryOperator
    {
        public LogicalOr(LogicalOperation left, LogicalOperation right) : base(left, right)
        {
        }

        protected override bool Operation(LogicalOperation left, LogicalOperation right) => left.GetValue() || right.GetValue();
    }

    class LogicalAnd : LogicalBinaryOperator
    {
        public LogicalAnd(LogicalOperation left, LogicalOperation right) : base(left, right)
        {
        }

        protected override bool Operation(LogicalOperation left, LogicalOperation right) => left.GetValue() && right.GetValue();
    }
}