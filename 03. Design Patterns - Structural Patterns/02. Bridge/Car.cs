namespace Bridge
{
    // Base class
    public class Car
    {
        public Car(Motor motor, Gear gear)
        {
            Motor = motor;
            Gear = gear;
        }

        public Motor Motor { get; set; }

        public Gear Gear { get; set; }
    }

    public class Sedan : Car
    {
        public Sedan(Motor motor, Gear gear) 
            : base(motor, gear)
        {
        }
    }

    public class Pickup : Car
    {
        public Pickup(Motor motor, Gear gear) 
            : base(motor, gear)
        {
        }
    }
}
