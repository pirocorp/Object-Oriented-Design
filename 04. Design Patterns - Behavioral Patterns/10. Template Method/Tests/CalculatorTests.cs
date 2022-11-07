namespace TemplateMethod.Tests
{
    using System;
    using System.Collections.Generic;

    public class CalculatorTests : TestFixture
    {
        private Calculator cut;

        protected override void SetUp()
        {
            this.cut = new Calculator();
            Console.WriteLine("Setup of calculatorTests class");
        }

        protected override IEnumerable<Func<bool>> GetTests()
        {
            return new List<Func<bool>>
            {
                () =>
                {
                    Console.WriteLine("3 + 2 shall be 5");
                    return this.cut.Add(3, 2) == 5;
                },
                () =>
                {
                    Console.WriteLine("10 + (-10) shall be 0");
                    return this.cut.Add(10, -10) == 0;
                },
            };
        }

        protected override void TearDown()
        {
            Console.WriteLine("Tear down of calculatorTests class");
        }
    }
}
