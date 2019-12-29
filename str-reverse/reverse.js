/**
 * Reverse part of input array according to provided range.
 * @param {char[]} chars Array of chars.
 * @param {number} start Start index.
 * @param {number} count End index.
 * @returns {char[]}
 */
function reverse(chars, start, end) {
    // range is too short for reversing
    if (end - start <= 1) {
        return chars;
    }

    // iterate just half of input
    const pivot = Math.trunc((end - start) / 2);
    for (let i = 0; i <= pivot; i++) {
        swap(chars, start + i, end - i);
    }

    return chars;
}

/**
 * Swaps two fields in array (encapsulates simple swapping).
 * @param {char[]} chars   Array of chars.
 * @param {number} idxFrom Source index.
 * @param {number} idxTo   Destination index.
 * @returns {char[]}
 */
function swap(chars, idxFrom, idxTo) {
    const temp = chars[idxFrom];
    chars[idxFrom] = chars[idxTo];
    chars[idxTo] = temp;

    return chars;
}

/**
 * Determines whether given char is white-space.
 * @param {char} char Character to check.
 * @returns {bool}
 */
function isWhiteSpace(char) {
    return char == ' ' || char == "\t";
}

/**
 * Reverse words in sentence.
 * @param {char[]} chars Array of chars.
 * @returns {char[]}
 */
function reverseSentence(chars) {
    // perform reversing of words from start to last space in sentence
    let start = 0;
    for (let i = 0; i < chars.length; i++) {
        if (isWhiteSpace(chars[i])) {
            reverse(chars, start, i - 1);
            start = i + 1;
        }
    }

    // reverse word from last space in sentence to the end
    reverse(chars, start, chars.length - 1);

    return chars;
}

// -----------------------------------------------------------------------------
// act
const sentence = 'this is a table'.split('');
const expected = 'siht si a elbat';

reverseSentence(sentence);

// -----------------------------------------------------------------------------
// assert
const assert = require('assert');
assert.equal(sentence.join(''), expected);

console.log('done!');