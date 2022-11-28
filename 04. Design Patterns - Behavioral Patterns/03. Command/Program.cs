namespace Command
{
    using Command.SwitchDemo;

    public static class Program
    {
        public static void Main()
        {
            var lamp = new Light();

            // Pass reference to the lamp instance to each command
            var switchClose = new CloseSwitchCommand(lamp);
            var switchOpen = new OpenSwitchCommand(lamp);

            var @switch = new Switch(switchClose, switchOpen);

            @switch.Close();
            @switch.Open();
        }
    }
}