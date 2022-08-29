namespace Singleton
{
    /// <summary>
    /// Thread save Singleton
    /// </summary>
    public class LoggerThreadSave
    {
        private static LoggerThreadSave? instance;
        private static readonly object padlock = new();

        private LoggerThreadSave()
        {
            
        }

        public static LoggerThreadSave Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new LoggerThreadSave();
                }

                return instance;
            }
        }
    }
}
