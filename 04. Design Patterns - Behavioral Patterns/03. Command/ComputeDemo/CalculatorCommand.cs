namespace Command.ComputeDemo
{
    using System;

    public class CalculatorCommand : ICommand
    {
        private readonly Calculator calculator;
        private readonly Operation operation;
        private readonly decimal operand;

        public CalculatorCommand(
            Calculator calculator, 
            Operation operation, 
            decimal operand)
        {
            this.calculator = calculator;
            this.operation = operation;
            this.operand = operand;
        }

        public void Execute()
        {
            this.calculator.Operation(this.operation, this.operand);
        }

        public void UnExecute()
        {
            this.calculator.Operation(Undo(this.operation), this.operand);
        }

        private static Operation Undo(Operation operation)
            => operation switch
            {
                Operation.Addition => Operation.Subtraction,
                Operation.Subtraction => Operation.Addition,
                Operation.Division => Operation.Multiplication,
                Operation.Multiplication => Operation.Division,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
    }
}
