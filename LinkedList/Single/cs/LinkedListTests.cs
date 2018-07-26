using System;
using Xunit;

namespace LinkedList
{
    public class LinkedListTests
    {
        [Fact]
        public void node_created_with_value_and_next_pointer_is_null()
        {
            ListNode<int> node = new ListNode<int>(1);

            Assert.NotNull(node);
            //Assert.NotNull(node.Value);
            Assert.Equal(1, node.Value);
            Assert.Null(node.Next);
        }

        [Fact]
        public void create_list_with_one_element()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);

            Assert.Equal(1, list.Length);
            Assert.NotNull(list.Head);
            Assert.Equal(1, list.Head.Value);
        }

        [Fact]
        public void crete_list_from_constructor()
        {
            LinkedList<int> list = new LinkedList<int>(1, 2, 3);

            Assert.Equal(3, list.Length);
            Assert.NotNull(list.Head);
            Assert.Equal(1, list.Head.Value);
        }

        [Fact]
        public void create_list_with_two_elements_and_next_pointer_is_set_correctly()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);
            list.AppendLast(2);

            Assert.Equal(2, list.Length);
            Assert.NotNull(list.Head.Next);
            Assert.Equal(2, list.Head.Next.Value);
        }

        [Fact]
        public void append_node_at_the_list_start()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendFirst(1);
            list.AppendFirst(2);

            Assert.Equal(2, list.Length);
            Assert.NotNull(list.Head.Next);
            Assert.Equal(1, list.Head.Next.Value);
        }

        [Fact]
        public void remove_node_should_be_zero_in_length()
        {
            LinkedList<int> list = new LinkedList<int>();

            var node = list.AppendFirst(1);
            list.RemoveNode(node);

            Assert.Equal(0, list.Length);
            Assert.Null(list.Head);
        }

        [Fact]
        public void remove_node_in_middle()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendFirst(1);
            var node = list.AppendFirst(2);
            list.AppendFirst(3);

            list.RemoveNode(node);

            Assert.Equal(2, list.Length);
            Assert.NotNull(list.Head);
            Assert.Equal(1, list.Head.Next.Value);
        }

        [Fact]
        public void remove_node_at_start()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);
            list.AppendLast(2);
            list.AppendFirst(3);

            list.RemoveAtStart();

            Assert.Equal(2, list.Length);
            Assert.NotNull(list.Head);
            Assert.Equal(1, list.Head.Value);
            Assert.Equal(2, list.Head.Next.Value);
        }

        [Fact]
        public void remove_node_at_end()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);
            list.AppendLast(2);
            list.AppendFirst(3);

            list.RemoveAtEnd();

            Assert.Equal(2, list.Length);
            Assert.NotNull(list.Head);
            Assert.Equal(3, list.Head.Value);
            Assert.Equal(1, list.Head.Next.Value);
        }

        [Fact]
        public void remove_the_only_node_from_start()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);

            list.RemoveAtStart();

            Assert.Equal(0, list.Length);
            Assert.Null(list.Head);
        }

        [Fact]
        public void remove_the_only_node_from_end()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AppendLast(1);

            list.RemoveAtEnd();

            Assert.Equal(0, list.Length);
            Assert.Null(list.Head);
        }
    }
}
