namespace ObjectPool
{
    using System;

    public class Rand
    {
        private static readonly Random random = new();

        public static int Next => random.Next(1000, 3500);
    }
}
