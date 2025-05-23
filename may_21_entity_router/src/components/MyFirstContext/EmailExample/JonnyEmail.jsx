import {useContext} from "react";
import {EmailContext} from "./EmailContext.jsx";

export function JonnyEmail() {

    const { email, setEmail } = useContext(EmailContext);

    const handleChange = (event) => {
        setEmail(event.target.value);
    }

    return (
        <div>
            <h2>Jonny Email</h2>
            <input type="text" value={email} onChange={handleChange} />
            <p>Current email: {email}</p>
        </div>
    );

}
