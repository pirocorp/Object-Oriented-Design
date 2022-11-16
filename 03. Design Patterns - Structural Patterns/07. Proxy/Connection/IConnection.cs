namespace Proxy.Connection
{
    /// <summary>
    /// Subject
    /// </summary>
    public interface IConnection
    {
        void ConnectTo(string host);
    }
}
