namespace Command.SwitchDemo
{
    /// <summary>
    /// The Invoker Class
    /// </summary>
    public class Switch
    {
        private readonly ISwitchCommand closeCommand;
        private readonly ISwitchCommand openCommand;

        public Switch(ISwitchCommand closeCommand, ISwitchCommand openCommand)
        {
            this.closeCommand = closeCommand;
            this.openCommand = openCommand;
        }

        /// <summary>
        /// Close the circuit / power on
        /// </summary>
        public void Close()
        {
            this.closeCommand.Execute();
        }

        /// <summary>
        /// Open the circuit / power off
        /// </summary>
        public void Open()
        {
            this.openCommand.Execute();
        }
    }
}
