namespace Factory_Method.Fans
{
    public class CeilingFan : IFan
    {
        private string fanState;

        public CeilingFan()
        {
            this.fanState = "Ceiling On";
        }

        public void SwitchOn() => this.fanState = "Ceiling On";

        public void SwitchOff() => this.fanState = "Ceiling Off";

        public string GetState() => $"Ceiling fan state {this.fanState}";
    }
}
