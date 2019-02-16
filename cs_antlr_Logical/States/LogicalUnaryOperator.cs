namespace cs_antlr_Logical.States
{
    abstract class LogicalUnaryOperator : LogicalOperation
    {
        public LogicalOperation Parameter { get; protected set; }

        public LogicalUnaryOperator(LogicalOperation parameter)
        {
            Parameter = parameter;
        }

        public override bool GetValue() => Operation(Parameter);

        protected abstract bool Operation(LogicalOperation parameter);

    }

    class LogicalParenthesis : LogicalUnaryOperator
    {
        public LogicalParenthesis(LogicalOperation parameter) : base(parameter)
        {
        }

        protected override bool Operation(LogicalOperation parameter) => parameter.GetValue();
    }

    class LogicalNot : LogicalUnaryOperator
    {
        public LogicalNot(LogicalOperation parameter) : base(parameter)
        {
        }

        protected override bool Operation(LogicalOperation parameter) => !parameter.GetValue();
    }
}