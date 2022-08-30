namespace Factory_Method.Fans
{
    public class TableFan : IFan
    {
        private string fanState;

        public TableFan()
        {
            this.fanState = "Table On";
        }

        public void SwitchOn() => this.fanState = "Table On";

        public void SwitchOff() => this.fanState = "Table Off";

        public string GetState() => $"Table fan state {this.fanState}";
    }
}
