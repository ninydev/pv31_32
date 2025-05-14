import "./my-first-form.css";
import {useEffect, useState} from "react";
import {
    hasLowerCase,
    hasNumber,
    hasSpecialCharacter,
    hasUpperCase,
    isLengthValid,
    isValidPassword
} from "./validations.js";

export function InputPassword() {

    const [password1, setPassword1] = useState("");
    const [password2, setPassword2] = useState("");

    const [isLength, setIsLength] = useState(false);
    const [isUpperCase, setIsUpperCase] = useState(false);
    const [isLowerCase, setIsLowerCase] = useState(false);
    const [isNumber, setIsNumber] = useState(false);
    const [isSpecialCharacter, setIsSpecialCharacter] = useState(false);
    const [isPasswordMatch, setIsPasswordMatch] = useState(false);
    const [isValid, setIsValid] = useState(false);

    useEffect(() => {
        setIsLength(isLengthValid(password1, 8))
        setIsUpperCase(hasUpperCase(password1))
        setIsLowerCase(hasLowerCase(password1))
        setIsNumber(hasNumber(password1))
        setIsSpecialCharacter(hasSpecialCharacter(password1))
    }, [password1]);

    useEffect(() => {
        setIsPasswordMatch(password1 === password2)
        setIsValid(isValidPassword(password1, password2))
    }, [password1, password2]);



    return (
        <div>
            <div>
                <ul>
                    <li className={isLength ? "valid": "error"}>Min len 8 chars</li>
                    <li className={isUpperCase ? "valid": "error"}>At least 1 uppercase letter</li>
                    <li className={isLowerCase ? "valid": "error"}>At least 1 lowercase letter</li>
                    <li className={isNumber ? "valid": "error"}>At least 1 number</li>
                    <li className={isSpecialCharacter ? "valid": "error"}>At least 1 special character</li>
                    <li className={isPasswordMatch ? "valid": "error"}>Confirm password</li>
                </ul>
            </div>

            <div>
                <label htmlFor="password">Password</label>
                <input type="password" id="password1" name="password1"
                       value={password1}
                       onChange={(e) => setPassword1(e.target.value)}/>
            </div>
            <div>
                <label htmlFor="password">Repiat Password</label>
                <input type="password" id="password2" name="password2"
                       value={password2}
                       onChange={(e) => setPassword2(e.target.value)}/>
            </div>
            <div>
                <input type="submit" value="Submit" disabled={!isValid}/>
            </div>
        </div>
    )

}