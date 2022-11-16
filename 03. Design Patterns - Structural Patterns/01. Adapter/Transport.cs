namespace Adapter
{
    /// <summary>
    /// Adapter
    /// </summary>
    public class Transport : ITransport
    {
        private readonly Bicycle bicycle = new ();

        public void Commute()
        {
            this.bicycle.Pedal();
        }
    }
}
