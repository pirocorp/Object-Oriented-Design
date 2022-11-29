namespace Command.SwitchDemo
{
    /// <summary>
    /// The Command for turning off the device - ConcreteCommand #1
    /// </summary>
    public class CloseSwitchCommand : ISwitchCommand
    {
        private readonly ISwitchable switchable;

        public CloseSwitchCommand(ISwitchable switchable)
        {
            this.switchable = switchable;
        }

        public void Execute()
        {
            this.switchable.PowerOn();
        }
    }
}
