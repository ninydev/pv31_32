import React from "react";

// Створюємо контекст для передачі даних між компонентами
const SomeDataContext = React.createContext()

// Компонент-провайдер, який надає доступ до контексту всім дочірнім компонентам
export const SomeDataProvider
    = ({children}) => {
    // Створюємо стан для зберігання даних та функцію для їх оновлення
    const [someData, setSomeData] = React.useState({})

    // Повертаємо провайдер з передачею значень стану та функції оновлення
    return(
        <SomeDataContext.Provider value={{someData, setSomeData}}>
            {children}
        </SomeDataContext.Provider>
    )
}
