/**
 * Class representing linked-list node.
 * @property {number} value Value of node.
 * @property {Node}   next  Next node in chain or {null} when last node.
 */
class Node {
    /**
     * @constructor
     * @param {number} value Node value.
     * @param {Node}   next  Next node in list.
     */
    constructor(value, next) {
        const intValue = Number.parseInt(value);
        if (Number.isNaN(intValue) || intValue < 0 || intValue > 9) {
            throw new Error(`Invalid value: ${value}`);
        }

        this.value = intValue;
        this.next = next;
    }

    /**
     * Builds {Node} out of numeric value passed.
     * @param {number|string} num Numeric value.
     * @returns {Node} First node of linked-list.
     */
    static build(num) {
        let result = null;
        for (let n of num.toString().split('').reverse()) {
            result = new Node(n, result);
        }

        return result;
    }
}

/**
 * Creates printable value from given linked-list.
 * @param {Node} node First linked-list node.
 * @returns {string} String representation of node.
 */
function print(node) {
    var stack = buildStack(node);

    return stack.length == 0
        ? '0'
        : stack.join('');
}

/**
 * Creates stack of values read from linked-list.
 * @param {Node} linkedList First linked-list node.
 * @returns {number[]} Array of linked-list values.
 */
function buildStack(linkedList) {
    const stack = [];

    let node = linkedList;
    while (node) {
        stack.push(node.value);
        node = node.next;
    }

    return stack;
}

/**
 * Creates ordered array of addends by stack size, londer stack is first.
 * @param {number[]} a First addend represented by array of digits.
 * @param {number[]} b Second addend represented by array of digits.
 * @returns {number[][]} Array of stacks where [0] is longer stack and [1] is shorter one.
 */
function sortAddendsByLength(a, b) {
    return a.length > b.length
        ? [a, b]
        : [b, a];
}

/**
 * Sums two addends together.
 * @param {number} a     First addend.
 * @param {number} b     Second addend.
 * @param {number} carry Add carry.
 * @returns {{sum: number, carry: number}}
 */
function add(a, b, carry) {
    let sum = a + b + carry;

    // always keep sum result in range [0..9], otherwise carry
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

/**
 * Reads first value from stack.
 * @param {number[]} stack Stack to pop value from.
 * @returns {number} First stack value of {0} if stack is empty.
 */
function readStack(stack) {
    return stack && stack.length > 0
        ? stack.pop()
        : 0;
}

/**
 * Sums two linked-lists.
 * @param {Node} a First addend
 * @param {Node} b Second addend
 * @returns {Node} Sum of {a} and {b}.
 */
function sum(a, b) {
    let [firstAddend, secondAddend] = sortAddendsByLength(
        buildStack(a),
        buildStack(b)
    );

    let carry = 0;
    let result = null;
    while (firstAddend.length > 0) {
        // pop stacks and perform sum
        const additionResult = add(
            readStack(firstAddend),
            readStack(secondAddend),
            carry
        );

        // insert new node into linked-list
        result = new Node(additionResult.sum, result);
        carry = additionResult.carry;
    }

    // if we carried something, add it at the start of linked-list
    if (carry > 0) {
        result = new Node(carry, result);
    }

    return result;
}

// -----------------------------------------------------------------------------
// act
const a = 666;
const b = 444;
const c = sum(Node.build(a), Node.build(b));

// -----------------------------------------------------------------------------
// assert
const assert = require('assert');
assert.equal(print(c), (a + b).toString());

console.log('done!');