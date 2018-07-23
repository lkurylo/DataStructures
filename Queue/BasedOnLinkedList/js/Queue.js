import {LinkedList} from '../../../LinkedList/Single/js/LinkedList';

export class Queue {
    constructor() {
        this.list = new LinkedList();
    }

    isEmpty() {
        return this.list.length === 0;
    }

    size() {
        return this.list.length;
    }

    enqueue(value) {
        this
            .list
            .append(value);
    }

    peek() {
        return this.list.Head.value;
    }

    dequeue() {
        if (this.list.length === 0) {
            throw new Error('Cannot dequeue from empty queue');
        }

        let value = this.list.Head.value;

        this
            .list
            .removeFirst();

        return value;
    }
}