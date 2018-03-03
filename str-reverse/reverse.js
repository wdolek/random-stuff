/**
 * @param char[] chars Array of chars
 * @param number start Start index
 * @param number count Number of chars to reverse
 */
function reverse(chars, start, end) {
    if (end - start < 1) {
        return chars;
    }

    const pivot = Math.trunc((end - start) / 2);
    for (let i = 0; i <= pivot; i++) {
        swap(chars, start + i, end - i);
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

/**
 * @param char char Character to check
 */
function isWhiteSpace(char) {
    return char == ' ' || char == "\t";
}

/**
 * @param char[] chars Array of chars
 */
function reverseSentence(chars) {
    let start = 0;
    for (let i = 0; i < chars.length; i++) {
        if (isWhiteSpace(chars[i])) {
            reverse(chars, start, i - 1);
            start = i + 1;
        }
    }

    reverse(chars, start, chars.length - 1);

    return chars;
}

// act
let word = 'this is a table'.split('');
console.log(word);
console.log(reverseSentence(word, 0, word.length));