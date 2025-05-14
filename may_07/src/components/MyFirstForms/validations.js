function isLengthValid(value, minLength) {
    return value.length >= minLength;
}

function hasUpperCase(value) {
    return /[A-Z]/.test(value);
}

function hasLowerCase(value) {
    return /[a-z]/.test(value);
}

function hasNumber(value) {
    return /\d/.test(value);
}

function hasSpecialCharacter(value) {
    return /[!@#$%^&*(),.?":{}|<>]/.test(value);
}

function isPasswordMatch(password1, password2) {
    return password1 === password2;
}

function isValidPassword(password1, password2) {
    return (
        isLengthValid(password1, 8) &&
        hasUpperCase(password1) &&
        hasLowerCase(password1) &&
        hasNumber(password1) &&
        hasSpecialCharacter(password1) &&
        isPasswordMatch(password1, password2)
    );
}
