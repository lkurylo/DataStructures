let assert = require('chai').assert;

import {
    LinkedListNode,
    LinkedList
} from '../LinkedList';

describe('Linked list tests', function() {
    it('create node with value and next pointer is null', function() {
        let node = new LinkedListNode(1);

        assert.equal(node.value, 1);
        assert.isNull(node.next);
    });

    it('create list with zero elements', function() {
        let list = new LinkedList();

        assert.equal(list.length, 0);
        assert.isNull(list.Head);
    });

    it('add new element and length should be one', function() {
        let list = new LinkedList();

        list.append(1);

        assert.equal(list.length, 1);
        assert.isNotNull(list.Head);
        assert.equal(list.Head.value, 1);
    });

    it('add two elements at the end, length and next pointer is set correct', function() {
        let list = new LinkedList();

        list.append(1);
        list.append(2);

        assert.equal(list.length, 2);
        assert.isNotNull(list.Head.next);
        assert.equal(list.Head.next.value, 2);
    });

    it('add two elements at the start, set new head', function() {
        let list = new LinkedList();

        list.prepend(1);
        list.prepend(2);

        assert.equal(list.length, 2);
        assert.isNotNull(list.Head.next);
        assert.equal(list.Head.value, 2);
        assert.equal(list.Head.next.value, 1);
    });

    it('add node after the second one', function() {
        let list = new LinkedList();

        list.append(1);
        let node = list.append(2);
        list.append(3);

        list.insertAfter(node, 4);

        assert.equal(list.length, 4);
        assert.equal(list.Head.next.next.value, 4);
        assert.equal(list.Head.next.next.next.value, 3);
    });

    it('remove the only one element', function() {
        let list = new LinkedList();

        list.append(1);

        list.removeLast();

        assert.equal(list.length, 0);
        assert.isNull(list.Head);
    });

    it('remove last element, length and next pointer should be set correctly',
        function() {
            let list = new LinkedList();

            list.append(1);
            list.append(2);

            list.removeLast();

            assert.equal(list.length, 1);
            assert.isNull(list.Head.next);
            assert.equal(list.Head.value, 1);
        });

    it('remove element at the beginning', function() {
        let list = new LinkedList();

        list.append(1);
        list.append(2);

        list.removeFirst();

        assert.equal(list.length, 1);
        assert.isNull(list.Head.next);
        assert.equal(list.Head.value, 2);
    });

    it('remove the only one node from the start', function() {
        let list = new LinkedList();

        list.append(1);

        list.removeFirst();

        assert.equal(list.length, 0);
        assert.isNull(list.Head);
    });
});