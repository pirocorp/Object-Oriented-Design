namespace Iterator.Boxes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BoxCollection : IEnumerable<Box>
    {
        private readonly List<Box> boxes;

        public BoxCollection(IEnumerable<Box> boxes)
        {
            this.boxes = boxes.ToList();
        }

        public int Count => boxes.Count;

        // Sets or Gets the element at the given index.
        public Box this[int index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((uint)index >= (uint)boxes.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "out of range");
                }

                return boxes[index];
            }

            set
            {
                if ((uint)index >= (uint)boxes.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "out of range");
                }

                boxes[index] = value;
            }
        }

        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
