using System;
using Xunit;
using static Heap.Heap;

namespace Heap
{
    public class MinHeapTests
    {
        [Fact]
        public void create_empty_heap_min()
        {
            Heap heap = new Heap(HeapType.Min);

            Assert.Equal(heap.Size(), 0);
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }

        [Fact]
        public void create_min_heap_with_single_element_and_no_children()
        {
            Heap heap = new Heap(HeapType.Min);
            heap.Append(1);

            Assert.Equal(heap.Size(), 1);
            Assert.Equal(heap.Peek(), 1);
        }

        [Fact]
        public void create_heap_with_two_elements_get_minimal_value()
        {
            Heap heap = new Heap(HeapType.Min);
            heap.Append(2);
            heap.Append(1);

            Assert.Equal(heap.Peek(), 1);
        }

        [Fact]
        public void create_heap_with_two_elements_get_maximum_value()
        {
            Heap heap = new Heap(HeapType.Max);
            heap.Append(2);
            heap.Append(1);

            Assert.Equal(heap.Peek(), 2);
        }

        [Fact]
        public void should_set_minimum_element_first_when_previous_popped()
        {
            Heap heap = new Heap(HeapType.Min);
            heap.Append(20);
            heap.Append(1);
            heap.Append(21);
            heap.Append(2);

            heap.Pop();

            Assert.Equal(heap.Peek(), 2);
        }

        [Fact]
        public void should_set_minimum_element_first_negative()
        {
            Heap heap = new Heap(HeapType.Min);
            heap.Append(-20);
            heap.Append(-1);
            heap.Append(-21);
            heap.Append(-2);

            Assert.Equal(heap.Peek(), -21);
        }

        [Fact]
        public void should_set_maximum_element_first_negative()
        {
            Heap heap = new Heap(HeapType.Max);
            heap.Append(-20);
            heap.Append(-1);
            heap.Append(-21);
            heap.Append(-2);

            Assert.Equal(heap.Peek(), -1);
        }

        [Fact]
        public void should_set_maximum_element_first_when_previous_popped()
        {
            Heap heap = new Heap(HeapType.Max);
            heap.Append(20);
            heap.Append(1);
            heap.Append(21);
            heap.Append(2);

            heap.Pop();

            Assert.Equal(heap.Peek(), 20);
        }

        [Fact]
        public void create_heap_and_pop_item_should_return_exception()
        {
            Heap heap = new Heap(HeapType.Min);

            Assert.Throws<InvalidOperationException>(() => heap.Pop());
        }

        [Fact]
        public void create_heap_with_one_element_pop_and_should_be_empty_collection()
        {
            Heap heap = new Heap(HeapType.Min);

            heap.Append(1);

            int expected = heap.Pop();

            Assert.Equal(heap.Size(), 0);
            Assert.Equal(expected, 1);
        }

        [Fact]
        public void delete_element_from_min_heap_in_middle()
        {
            Heap heap = new Heap(HeapType.Min);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(10);

            Assert.Equal(heap.Pop(), 2);
            Assert.Equal(heap.Pop(), 4);
            Assert.Equal(heap.Pop(), 30);
            Assert.Equal(heap.Pop(), 53);
        }

        [Fact]
        public void delete_element_from_min_heap_first_one()
        {
            Heap heap = new Heap(HeapType.Min);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(2);

            Assert.Equal(heap.Pop(), 4);
            Assert.Equal(heap.Pop(), 10);
            Assert.Equal(heap.Pop(), 30);
            Assert.Equal(heap.Pop(), 53);
        }

        [Fact]
        public void delete_element_from_min_heap_last_one()
        {
            Heap heap = new Heap(HeapType.Min);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(53);

            Assert.Equal(heap.Pop(), 2);
            Assert.Equal(heap.Pop(), 4);
            Assert.Equal(heap.Pop(), 10);
            Assert.Equal(heap.Pop(), 30);
        }

        [Fact]
        public void delete_element_from_max_heap_in_middle()
        {
            Heap heap = new Heap(HeapType.Max);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(10);

            Assert.Equal(heap.Pop(), 53);
            Assert.Equal(heap.Pop(), 30);
            Assert.Equal(heap.Pop(), 4);
            Assert.Equal(heap.Pop(), 2);
        }

        [Fact]
        public void delete_element_from_max_heap_first_one()
        {
            Heap heap = new Heap(HeapType.Max);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(53);

            Assert.Equal(heap.Pop(), 30);
            Assert.Equal(heap.Pop(), 10);
            Assert.Equal(heap.Pop(), 4);
            Assert.Equal(heap.Pop(), 2);
        }

        [Fact]
        public void delete_element_from_max_heap_last_one()
        {
            Heap heap = new Heap(HeapType.Max);

            heap.Append(10);
            heap.Append(2);
            heap.Append(30);
            heap.Append(4);
            heap.Append(53);

            heap.Delete(2);

            Assert.Equal(heap.Pop(), 53);
            Assert.Equal(heap.Pop(), 30);
            Assert.Equal(heap.Pop(), 10);
            Assert.Equal(heap.Pop(), 4);
        }
    }
}
