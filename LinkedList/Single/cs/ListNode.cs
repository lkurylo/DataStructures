using System;

namespace LinkedList
{
    public class ListNode<T>
    {
        private T value;

        public ListNode(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }

        public ListNode<T> Next { get; private set; }

        public void SetNext(ListNode<T> node)
        {
            this.Next = node;
        }
    }

    public class LinkedList<T>
    {
        public ListNode<T> Head { get; private set; }
        public int Length { get; private set; }

        public LinkedList()
        {

        }

        public LinkedList(params T[] values)
        {
            foreach (var val in values)
            {
                this.AppendLast(val);
            }
        }

        public ListNode<T> AppendLast(T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);

            var head = this.Head;

            if (head == null)
            {
                this.Head = newNode;
            }
            else
            {
                while (head.Next != null)
                {
                    head = head.Next;
                }

                head.SetNext(newNode);
            }

            this.Length++;

            return newNode;
        }

        public ListNode<T> AppendFirst(T value)
        {
            ListNode<T> newNode = new ListNode<T>(value);

            if (this.Head == null)
            {
                this.Head = newNode;
            }
            else
            {
                var copy = this.Head;
                newNode.SetNext(this.Head);
                this.Head = newNode;
            }

            this.Length++;

            return newNode;
        }

        public void RemoveNode(ListNode<T> node)
        {
            if (node == this.Head)
            {
                this.Head = this.Head.Next;
                this.Length--;
            }
            else
            {
                var head = this.Head;

                while (head != null && head.Next != node)
                {
                    head = head.Next;
                }

                if (head != null)
                {
                    head.SetNext(node.Next);

                    this.Length--;
                }
            }
        }

        public void RemoveAtStart()
        {
            if (this.Head != null)
            {
                this.Head = this.Head.Next;
                this.Length--;
            }
        }

        public void RemoveAtEnd()
        {
            var head = this.Head;

            while (head != null && head.Next != null)
            {
                if (head.Next.Next != null)
                {
                    head = head.Next;
                }
                else
                {
                    break;
                }
            }

            if (head != null)
            {
                if (head == this.Head)
                {
                    this.Head = null;
                }
                else
                {
                    head.SetNext(null);
                }

                this.Length--;
            }
        }
    }
}