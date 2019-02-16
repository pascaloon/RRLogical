namespace cs_antlr_Logical.States
{
    class LogicalConstant : LogicalOperation
    {
        private bool _value;
        public override bool GetValue() => _value;

        public LogicalConstant(string value)
        {
            _value = int.Parse(value) == 1;
        }
    }
}