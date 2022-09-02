namespace Singleton.Singletons
{
    /// <summary>
    /// In this pattern instantiation is triggered by the first reference
    /// to the static member of the nested class, which only occurs in Instance.
    /// </summary>
    public class LoggerFullLazy : Spool, ILogger<LoggerFullLazy>
    {
        private LoggerFullLazy()
        {
        }

        public static LoggerFullLazy Instance => Nested.LazyInstance;

        private static class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {}

            internal static readonly LoggerFullLazy LazyInstance = new ();
        }
    }
}
