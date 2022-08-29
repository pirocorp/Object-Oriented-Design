namespace Singleton
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var logger = LoggerThreadSave.Instance;
            var secondLogger = LoggerThreadSave.Instance;

            Console.WriteLine(logger == secondLogger);
            Console.WriteLine(logger.GetHashCode() == secondLogger.GetHashCode());
        }
    }
}