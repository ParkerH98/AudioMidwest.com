﻿// this function uses regular expressions to format phone numbers
    // formats 10 digit phone number
    var match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/)
    // returns newly formatted string
        return ['(', match[2], ') ', match[3], '-', match[4]].join('')
    return null

// event listener that detects a key press
    // sets the text box value as the newly formatted string
}, false);