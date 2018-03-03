class Node {
    constructor(value, next) {
        const intValue = Number.parseInt(value);
        if (Number.isNaN(intValue) || intValue < 0 || intValue > 9) {
            throw new Error(`Invalid value: ${value}`);
        }

        this.value = intValue;
        this.next = next;
    }

    static build(num) {
        let result = null;
        for (let n of num.toString().split('').reverse()) {
            result = new Node(Number.parseInt(n), result);
        }

        return result;
    }
}

function print(node) {
    var stack = buildStack(node);

    return stack.length == 0
        ? '0'
        : stack.join('');
}

function buildStack(linkedList) {
    const stack = [];

    let node = linkedList;
    while (node) {
        stack.push(node.value);
        node = node.next;
    }

    return stack;
}

function sortAddendsByLength(a, b) {
    return a.length > b.length
        ? [a, b]
        : [b, a];
}

function add(a, b, carry) {
    let sum = a + b + carry;

    if (sum >= 10) {
        sum = sum - 10;
        carry = 1;
    } else {
        carry = 0;
    }

    return {
        sum,
        carry
    }
}

function readStack(stack) {
    return stack && stack.length > 0
        ? stack.pop()
        : 0;
}

function sum(a, b) {
    let [firstAddend, secondAddend] = sortAddendsByLength(
        buildStack(a),
        buildStack(b)
    );

    let carry = 0;
    let result = null;
    while (firstAddend.length > 0) {
        const additionResult = add(
            readStack(firstAddend),
            readStack(secondAddend),
            carry
        );

        result = new Node(additionResult.sum, result);
        carry = additionResult.carry;
    }

    if (carry > 0) {
        result = new Node(1, result);
    }

    return result;
}

// -----------------------------------------------------------------------------
// act
const a = 666;
const b = 444;

const c = sum(Node.build(a), Node.build(b));

// assert
const assert = require('assert');
assert.equal(print(c), (a + b).toString());

console.log('done!');