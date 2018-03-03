/**
 * @param char[] chars Array of chars
 * @param number start Start index
 * @param number count Number of chars to reverse
 */
function reverse(chars, start, count) {
    const end = count - 1;
    if (start >= end) {
        return chars;
    }

    const pivot = start + (end - start) / 2;
    for (let i = start; i < pivot; i++) {
        swap(chars, i, (end - i));
    }

    return chars;
}

/**
 * @param char[] chars   Array of chars
 * @param number idxFrom Source index
 * @param number idxTo   Destination index
 */
function swap(chars, idxFrom, idxTo) {
    const temp = chars[idxFrom];
    chars[idxFrom] = chars[idxTo];
    chars[idxTo] = temp;

    return chars;
}

// act
let word = 'table'.split('');
console.log(word);
console.log(reverse(word, 0, word.length));