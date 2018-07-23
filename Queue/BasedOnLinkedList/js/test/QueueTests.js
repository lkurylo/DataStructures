const assert = require('chai').assert;

import {Queue} from '../Queue';

describe('Queue tests', function () {
    it('new queue instance is empty', function () {
        let queue = new Queue();

        assert.isNotNull(queue);
        assert.isTrue(queue.isEmpty());
        assert.equal(queue.size(), 0);
    });

    it('enqueue new item with size set to 1', function () {
        let queue = new Queue();

        queue.enqueue(1);

        assert.isFalse(queue.isEmpty());
        assert.equal(queue.size(), 1);
    });

    it('peek item from queue should not remove it from queue', function () {
        let queue = new Queue();

        queue.enqueue(1);
        let item = queue.peek();

        assert.isFalse(queue.isEmpty());
        assert.equal(queue.size(), 1);
        assert.equal(item, 1);
    });

    it('dequeue item from the queue, element should be deleted', function () {
        let queue = new Queue();

        queue.enqueue(1);
        let item = queue.dequeue();

        assert.isTrue(queue.isEmpty());
        assert.equal(queue.size(), 0);
        assert.equal(item, 1);
    });

    it('dequeue on empty queue should result in exception', function () {
        let queue = new Queue();

        assert.throw(queue.dequeue.bind(queue), Error);
    });
});