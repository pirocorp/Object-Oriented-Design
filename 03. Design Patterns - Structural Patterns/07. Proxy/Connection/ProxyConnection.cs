namespace Proxy.Connection
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proxy
    /// </summary>
    public class ProxyConnection : IConnection
    {
        private readonly IConnection directConnection;
        private readonly HashSet<string> bannedHosts;

        public ProxyConnection()
        {
            this.directConnection = new DirectConnection();
            this.bannedHosts = new HashSet<string>
            {
                "abc.com",
                "def.com",
                "ijk.com",
                "lnm.com"
            };
        }

        public void ConnectTo(string host)
        {
            if (this.bannedHosts.Contains(host.ToLower()))
            {
                throw new InvalidOperationException("Access Denied!");
            }

            this.directConnection.ConnectTo(host);
        }
    }
}
