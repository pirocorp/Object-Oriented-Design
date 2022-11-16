namespace Proxy.Connection
{
    using System;

    /// <summary>
    /// Real Subject
    /// </summary>
    public class DirectConnection : IConnection
    {
        public void ConnectTo(string host)
        {
            Console.WriteLine($"Connecting to {host}");
        }
    }
}
