namespace Command.SwitchDemo
{
    /// <summary>
    /// The Command for turning on the device - ConcreteCommand #2
    /// </summary>
    public class OpenSwitchCommand : ICommand
    {
        private readonly ISwitchable switchable;

        public OpenSwitchCommand(ISwitchable switchable)
        {
            this.switchable = switchable;
        }

        public void Execute()
        {
            this.switchable.PowerOff();
        }
    }
}
