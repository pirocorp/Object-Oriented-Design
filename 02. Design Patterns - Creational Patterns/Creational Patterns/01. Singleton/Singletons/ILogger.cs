namespace Singleton.Singletons
{
    using System.Collections.Generic;

    public interface ILogger<out T>
    {
        #pragma warning disable CA2252 // This API requires opting into preview features
        static abstract T Instance { get; }
        #pragma warning restore CA2252 // This API requires opting into preview features

        List<string> Queue { get; }
    }
}
