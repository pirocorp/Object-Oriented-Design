namespace Factory_Method.Fans
{
    public interface IFan
    {
        void SwitchOn();

        void SwitchOff();

        string GetState();
    }
}
