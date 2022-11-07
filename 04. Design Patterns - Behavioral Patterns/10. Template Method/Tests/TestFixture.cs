namespace TemplateMethod.Tests
{
    using System;
    using System.Collections.Generic;

    public abstract class TestFixture
    {
        public bool Run()
        {
            var failedTestCount = 0;

            foreach (var test in GetTests())
            {
                SetUp();
                if (!test())
                {
                    ++failedTestCount;
                }

                TearDown();
            }

            return failedTestCount == 0;
        }

        protected abstract IEnumerable<Func<bool>> GetTests();

        protected abstract void SetUp();

        protected abstract void TearDown();
    }
}
