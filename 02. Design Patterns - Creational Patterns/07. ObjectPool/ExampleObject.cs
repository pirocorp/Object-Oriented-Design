namespace ObjectPool
{
    using System;

    /// <summary>
    /// A toy class that requires some resources to create.
    /// </summary>
    public class ExampleObject
    {
        public int[] Nums { get; set; }

        public ExampleObject()
        {
            Nums = new int[1000000];
            var rand = new Random();

            for (var i = 0; i < Nums.Length; i++)
            {
                Nums[i] = rand.Next();
            }
        }

        public double GetValue(long i) => Math.Sqrt(Nums[i]);
    }
}
