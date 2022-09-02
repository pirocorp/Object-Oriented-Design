namespace Singleton.Singletons
{
    /// <summary>
    /// Thread save Singleton
    ///
    /// This pattern is not recommended and has a number of issues.
    ///
    /// The volatile keyword indicates that a field might be modified
    /// by multiple threads that are executing at the same time.
    /// The compiler, the runtime system, and even hardware may rearrange
    /// reads and writes to memory locations for performance reasons.
    /// Fields that are declared volatile are not subject to these optimizations.
    /// Adding the volatile modifier ensures that all threads will observe
    /// volatile writes performed by any other thread in the order in which they were performed.
    /// </summary>
    public class LoggerDoubleCheckLockSingleton : Spool, ILogger<LoggerDoubleCheckLockSingleton>
    {
        private static readonly object Padlock = new();

        private static volatile LoggerDoubleCheckLockSingleton? instance;

        public static LoggerDoubleCheckLockSingleton Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                
                lock (Padlock)
                {
                    if (instance == null)
                    {
                        instance = new LoggerDoubleCheckLockSingleton();
                    }
                }
                return instance;
            }
        }
    }
}
