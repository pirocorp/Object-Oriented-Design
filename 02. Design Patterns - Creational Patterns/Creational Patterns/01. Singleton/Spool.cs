namespace Singleton
{
    using System.Collections.Generic;

    public abstract class Spool
    {
        public List<string> Queue { get; } = new List<string>();
    }
}
