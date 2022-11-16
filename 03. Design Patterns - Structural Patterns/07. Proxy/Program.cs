// A real world example can be a cheque or credit card is a proxy
// for what is in our bank account. It can be used in place of cash,
// and provides a means of accessing that cash when required.
// And that’s exactly what the Proxy pattern does –
// “Controls and manage access to the object they are protecting“.
namespace Proxy
{
    using System;
    using Connection;

    public static class Program
    {
        public static void Main()
        {
            var proxy = new ProxyConnection();

            try
            {
                proxy.ConnectTo("google.com");
                proxy.ConnectTo("abc.com");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}