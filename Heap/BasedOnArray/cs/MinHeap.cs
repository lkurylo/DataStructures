using System;
using System.Collections.Generic;

namespace Heap
{
    public class Heap
    {
        public enum HeapType
        {
            Min,
            Max
        }

        private HeapType type;

        public Heap(HeapType type)
        {
            this.type = type;
        }

        private List<int> elements = new List<int>();

        public int Size() => elements.Count;

        public void Append(int i)
        {
            elements.Add(i);

            HeapifyUp();
        }

        public void Delete(int i)
        {
            if (elements.Count > 0)
            {
                int index = elements.IndexOf(i);

                if (index < 0)
                {
                    throw new ArgumentException("Element not found in Heap");
                }

                var current = elements[index];

                if (index < elements.Count - 1)
                {
                    elements[index] = elements[elements.Count - 1];

                    elements.RemoveAt(index);

                    if (!HasParent(index) || GetParent(index) < elements[index])
                    {
                        HeapifyDown();
                    }
                    else
                    {
                        HeapifyUp();
                    }
                }
                else
                {
                    elements.RemoveAt(index);
                }
            }
            else
            {
                throw new InvalidOperationException("Heap is empty");
            }
        }

        public int Peek()
        {
            if (elements.Count > 0)
            {
                return elements[0];
            }

            throw new InvalidOperationException("Heap is empty");
        }

        public int Pop()
        {
            if (elements.Count > 0)
            {
                int current = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                HeapifyDown();

                return current;
            }

            throw new InvalidOperationException("Heap is empty");
        }

        private void HeapifyDown()
        {
            int level = 0;

            while (HasLeftChild(level))
            {
                var index = LeftChildIndex(level);

                if (type == HeapType.Min)
                {
                    if (HasRightChild(level) &&
                        RightChild(level) < LeftChild(level))
                    {
                        index = RightChildIndex(level);
                    }

                    if (elements[index] >= elements[level]) break;
                }
                else
                {
                    if (HasRightChild(level) &&
                                            RightChild(level) > LeftChild(level))
                    {
                        index = RightChildIndex(level);
                    }

                    if (elements[index] < elements[level]) break;
                }

                SwapValues(index, level);
                level = index;
            }
        }

        private void HeapifyUp()
        {
            int level = elements.Count - 1;

            if (type == HeapType.Min)
            {
                while (HasParent(level) && GetParent(level) > elements[level])
                {
                    SwapValues(GetParentIndex(level), level);
                    level = GetParentIndex(level);
                }
            }
            else
            {
                while (HasParent(level) && GetParent(level) < elements[level])
                {
                    SwapValues(GetParentIndex(level), level);
                    level = GetParentIndex(level);
                }
            }
        }

        private bool HasParent(int level) => GetParentIndex(level) >= 0;

        private int GetParent(int level) => elements[GetParentIndex(level)];

        private int GetParentIndex(int level) => (level - 1) / 2;

        private bool HasLeftChild(int level) =>
            LeftChildIndex(level) < elements.Count;

        private int LeftChildIndex(int level) => 2 * level + 1;

        private int LeftChild(int level)
        {
            if (HasLeftChild(level))
            {
                return elements[LeftChildIndex(level)];
            }

            throw new InvalidOperationException("Left child does not exist");
        }

        private bool HasRightChild(int level) =>
            RightChildIndex(level) < elements.Count;

        private int RightChildIndex(int level) => 2 * level + 2;

        private int RightChild(int level)
        {
            if (HasRightChild(level))
            {
                return elements[RightChildIndex(level)];
            }

            throw new InvalidOperationException("Right child does not exist");
        }

        private void SwapValues(int leftIndex, int rightIndex)
        {
            int temp = elements[leftIndex];
            elements[leftIndex] = elements[rightIndex];
            elements[rightIndex] = temp;
        }
    }
}
