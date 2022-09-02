namespace Singleton.Singletons;

using Singleton;

/// <summary>
/// Thread save Singleton
///
/// This pattern is not recommended and has a number of issues.
/// </summary>
public sealed class LoggerSimpleThreadSave : Spool, ILogger<LoggerSimpleThreadSave>
{
    private static readonly object Padlock = new();

    private static LoggerSimpleThreadSave? instance;

    private LoggerSimpleThreadSave()
    {
    }

    public static LoggerSimpleThreadSave Instance
    {
        get
        {
            if (instance is not null)
            {
                return instance;
            }

            lock (Padlock)
            {
                instance ??= new LoggerSimpleThreadSave();
            }

            return instance;
        }
    }
}
