
export function InputForms() {

// Функція обробляє подію відправки форми
    const onSubmit = (event) => {

        // Зупиняє стандартну поведінку браузера при відправці форми
        event.preventDefault();

        // Створює об'єкт FormData з елементів форми, яка викликала подію
        const formData = new FormData(event.target);

        // Перетворює FormData у звичайний об'єкт
        const data = Object.fromEntries(formData.entries());

        // Виводить отримані дані у консоль
        console.log(data);

        if (data.password !== data.password2) {
            console.error("Passwords do not match");
            return;
        }

        if (data.password.length < 6) {
            console.error("Password is too short");
            return;
        }

        // Тут можна виконати додаткові дії з отриманими даними, наприклад, відправити їх на сервер

        console.log("Form submitted");
    }

    const onClickPolicy = (event) => {
        event.preventDefault();
        console.log("Policy clicked");
    }


    return (
        <form method="GET" onSubmit={onSubmit}>
            <h1> use form tag </h1>
            <label>Name: <input type="text" name="name"/></label><br />
            <label>Email: <input type="email" name="email"/></label><br />
            <label>Password: <input type="password" name="password"/></label><br />
            <label>Repeat Password: <input type="password" name="password2"/></label><br />
            <a href="/?goPolicy" onClick={onClickPolicy}> Policy </a>
            <input type="submit"/>
        </form>
    )

}