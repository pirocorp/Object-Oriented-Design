namespace ChainOfResponsibility.Loggers
{
    using System;

    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask) 
            : base(mask)
        { }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to console: " + msg);
        }
    }
}
