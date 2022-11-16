// Bridge design pattern. Instead of expressing a trait of a base class as
// another layer in the inheritance hierarchy, we split the inheritance hierarchy
// in two. We simply add a new class for the trait and then add inheritors
// of the trait. Then, the base class will contain a trait object within.
namespace Bridge
{
    public static class Program
    {
        public static void Main()
        {
            var electricPickupWithManualGear = new Pickup(new ElectricMotor(), new ManualGear());
            var petrolSedanWithAutomaticGear = new Sedan(new PetrolMotor(), new AutomaticGear());
        }
    }
}
