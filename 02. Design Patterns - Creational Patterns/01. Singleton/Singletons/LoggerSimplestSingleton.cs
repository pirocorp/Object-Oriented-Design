namespace Singleton.Singletons;

using Singleton;

/// <summary>
/// This is not recommended implementation of the Singleton Pattern
/// 
/// Not thread save Singleton
///
/// In the bellow example, it is possible for the instance to be created
/// before the expression is evaluated, but the memory model doesn’t
/// guarantee that the new value of instance will be seen by other threads
/// unless suitable memory barriers have been passed.
/// </summary>
public sealed class LoggerSimplestSingleton : Spool, ILogger<LoggerSimplestSingleton>
{
    private static LoggerSimplestSingleton? instance;

    private LoggerSimplestSingleton()
    {
    }

    // Null coalescing operator https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
    
    public static LoggerSimplestSingleton Instance => instance ??= new LoggerSimplestSingleton();
}
