namespace Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BoxIterator : IEnumerator<Box>
    {
        private readonly BoxCollection collection;
        private int currentIndex;
        private Box? currentBox;

        public BoxIterator(BoxCollection collection)
        {
            this.collection = collection;
            this.currentIndex = -1;
            this.currentBox = default;
        }

        public Box Current => this.currentBox ?? throw new InvalidOperationException();

        object IEnumerator.Current => this.Current;

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++this.currentIndex >= this.collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                this.currentBox = this.collection[this.currentIndex];
            }

            return true;
        }

        public void Reset()
            => this.currentIndex = -1;

        void IDisposable.Dispose() { }
    }
}
