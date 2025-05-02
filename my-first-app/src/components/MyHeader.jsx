import {useState} from "react";

function MyHeader() {

    // Ця зминна буде сторюватися кожного разу при рендерингу
    // тому вона на початку буде 0 а потім  всегда буде 1
    let clicksCount = 0;

    // Ця змінна буде зберігатися в пам'яті браузера
    // тому вона буде зберігатися між рендерингами
    let [count, setCount] = useState(0);

    const clickButton = (e) => {
        e.preventDefault();
        clicksCount++;
        setCount(count + 1);
        console.log("count: ", count);
        console.log("clicksCount: ", clicksCount);
    }


    return(<>
        <header className="masthead">
            <div className="container">
                <div className="masthead-subheading">Welcome To Our Studio!</div>
                <div className="masthead-heading text-uppercase">It's Nice To Meet You</div>
                <a onClick={clickButton} className="btn btn-primary btn-xl text-uppercase">Clicks: {clicksCount} {count}</a>
            </div>
        </header>
    </>)
}

export default MyHeader;