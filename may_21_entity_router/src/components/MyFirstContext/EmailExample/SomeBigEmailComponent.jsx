import {EmailProvider} from "./EmailContext.jsx";
import {SunnyEmail} from "./SunnyEmail.jsx";
import {JonnyEmail} from "./JonnyEmail.jsx";

export default () => {
    return(
        <>
        <EmailProvider>
            <h1> Test Context Idea</h1>
            <SunnyEmail />
            <JonnyEmail />
        </EmailProvider>
        </>
    )
}