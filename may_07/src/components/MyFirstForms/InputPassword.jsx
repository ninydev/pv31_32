export function InputPassword() {
    return (
        <div>
            <div>
                <ul>
                    <li>Min len 8 chars</li>
                    <li>At least 1 uppercase letter</li>
                    <li>At least 1 lowercase letter</li>
                    <li>At least 1 number</li>
                    <li>At least 1 special character</li>
                    <li>Confirm password</li>
                </ul>
            </div>

            <div>
                <label htmlFor="password">Password</label>
                <input type="password" id="password1" name="password1"/>
            </div>
            <div>
                <label htmlFor="password">Repiat Password</label>
                <input type="password" id="password2" name="password2"/>
            </div>
            <div>
                <input type="submit" value="Submit"/>
            </div>
        </div>
    )

}