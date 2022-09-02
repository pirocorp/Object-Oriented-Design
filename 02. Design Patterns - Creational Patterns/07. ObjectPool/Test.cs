namespace ObjectPool
{
    using System;

    public class Test
    {
        private static int index = 0;

        public Test()
        {
            this.Id = $"Pooled Object: {index++}";
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
