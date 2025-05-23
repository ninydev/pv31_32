import {useContext} from "react";
import {EmailContext} from "./EmailContext.jsx";

export function OtherEmailComponent() {

    const { email } = useContext(EmailContext);

    return (
        <div>
            <h2>Other Component</h2>
            <p>{email}</p>
        </div>
    );
}