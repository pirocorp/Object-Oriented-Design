namespace Singleton.Singletons
{
    /// <summary>
    ///
    /// This pattern also incurs a performance hit.
    ///
    /// static constructors in C# execute only when an instance of
    /// the class is created or a static member is referenced,
    /// and to execute only once per AppDomain. The check for the type
    /// being newly constructed needs to be executed whatever else happens,
    /// it will be faster than adding extra checking as in the previous examples.
    ///
    /// This approach is still not ideal and actually has some issues because
    /// if you have static members other than Instance, the first reference
    /// to those members will involve creating the instance.
    ///
    /// There are also additional complications in that if one static constructor
    /// invokes another which invokes the first again. The laziness of type
    /// initializers are only guaranteed by .NET when the type isn’t marked with
    /// a special flag called beforefieldinit.
    /// 
    /// </summary>
    public class LoggerAlmostLazySingleton : Spool, ILogger<LoggerAlmostLazySingleton>
    {
        static LoggerAlmostLazySingleton()
        {
        }

        private LoggerAlmostLazySingleton()
        {
        }

        public static LoggerAlmostLazySingleton Instance { get; } = new ();
    }
}
