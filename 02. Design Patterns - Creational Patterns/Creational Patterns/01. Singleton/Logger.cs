namespace Singleton
{
    /// <summary>
    /// Not thread save Singleton
    /// </summary>
    public class Logger
    {
        private static Logger? instance;

        private Logger()
        {
        }

        public static Logger Instance => instance ??= new Logger();
    }
}
