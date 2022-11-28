namespace Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SimpleIterator<T> : IEnumerable<T>
    {
        private readonly List<T?> collection;

        public SimpleIterator()
        {
            this.collection = new List<T?>();
        }

        public T this[int index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((uint)index >= (uint)this.collection.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "out of range");
                }

                return this.collection[index];
            }

            set
            {
                if ((uint)index >= (uint)this.collection.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "out of range");
                }

                this.collection[index] = value;
            }
        }

        public void Add(T item) => this.collection.Add(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
