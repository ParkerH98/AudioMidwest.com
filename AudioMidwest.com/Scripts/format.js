// this function uses regular expressions to format phone numbersfunction formatPhoneNumber(phoneNumberString) {
    // formats 10 digit phone number    // e.g. 4053397877 --> (405) 339-7877    var cleaned = ('' + phoneNumberString).replace(/\D/g, '')
    var match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/)
    // returns newly formatted string    if (match) {
        return ['(', match[2], ') ', match[3], '-', match[4]].join('')    }
    return null}
// has to be the ID of the item you want to formatvar tbox = document.getElementById("tboxPhoneNumber");
// event listener that detects a key presstbox.addEventListener('keyup', function (evt) {    // passes text box value into formatPhoneNumber function    var formatted = formatPhoneNumber(this.value)
    // sets the text box value as the newly formatted string    tbox.value = formatted.toLocaleString();
}, false);