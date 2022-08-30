// ReSharper disable InvalidXmlDocComment
namespace Singleton.Singletons
{
    using System;

    /// <summary>
    /// The .net framework has some really cool features that and System.Lazy<T>
    /// is one of those features to help provide lazy initialization with
    /// access from multiple threads.
    ///
    /// The code below implicitly uses LazyThreadSafetyMode.ExecutionAndPublication
    /// as the thread safety mode for the Lazy<LoggerGenericLazyImplementation>.
    /// </summary>
    public class LoggerGenericLazyImplementation : Spool, ILogger<LoggerGenericLazyImplementation>
    {
        private static readonly Lazy<LoggerGenericLazyImplementation> Lazy;

        static LoggerGenericLazyImplementation()
        {
            Lazy = new Lazy<LoggerGenericLazyImplementation>(
                () => new LoggerGenericLazyImplementation());
        }

        private LoggerGenericLazyImplementation()
        {
        }

        public static LoggerGenericLazyImplementation Instance => Lazy.Value;
    }
}
