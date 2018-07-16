export class LinkedListNode {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

export class LinkedList {
    constructor() {
        this.length = 0;
        this.Head = null;
    }

    append(value) {
        let newNode = new LinkedListNode(value);
        let node = null;

        if (this.Head === null) {
            this.Head = newNode;
        } else {
            node = this.Head;

            while (node.next !== null) {
                node = node.next;
            }

            node.next = newNode;
        }

        this.length++;

        return newNode;
    }

    prepend(value) {
        let newNode = new LinkedListNode(value);

        if (this.Head === null) {
            this.Head = newNode;
        } else {
            newNode.next = this.Head;
            this.Head = newNode;
        }

        this.length++;

        return newNode;
    }

    insertAfter(node, value) {
        let newNode = new LinkedListNode(value);

        if (node !== null) {
            newNode.next = node.next;
            node.next = newNode;
        } else {
            throw new Error('Node cannot be null');
        }

        this.length++;

        return newNode;
    }

    removeLast() {
        let lastNode = this.Head;
        let prev = null;

        if (this.Head !== null) {
            if (this.Head.next === null) {
                this.Head = null;
            } else {
                while (lastNode.next !== null) {
                    prev = lastNode;
                    lastNode = lastNode.next;
                }

                prev.next = null;
            }

            this.length--;
        }
    }

    removeFirst() {
        if (this.Head !== null) {
            if (this.Head.next === null) {
                this.Head = null;
            } else {
                this.Head = this.Head.next;
            }

            this.length--;
        }
    }
}