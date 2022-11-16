// The Adapter Design Pattern, also known as the Wrapper,
// allows two classes to work together that otherwise
// would have incompatible interfaces.
namespace Adapter
{
    public static class Program
    {
        public static void Main()
        {
            var transport = new Transport();
            transport.Commute();
        }
    }
}
