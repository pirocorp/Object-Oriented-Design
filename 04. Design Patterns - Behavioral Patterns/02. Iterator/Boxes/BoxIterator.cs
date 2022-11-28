namespace Iterator.Boxes
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
            currentIndex = -1;
            currentBox = default;
        }

        public Box Current => currentBox ?? throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++currentIndex >= collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                currentBox = collection[currentIndex];
            }

            return true;
        }

        public void Reset()
            => currentIndex = -1;

        void IDisposable.Dispose() { }
    }
}
