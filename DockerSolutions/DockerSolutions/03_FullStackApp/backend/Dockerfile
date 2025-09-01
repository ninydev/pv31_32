# Базовий образ для запуску ASP\.NET Core додатку
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Встановлюємо робочу директорію всередині контейнера
WORKDIR /app

# Відкриваємо порти 8080 та 8081 для доступу до додатку
EXPOSE 5001
EXPOSE 7037

# Базовий образ для збірки додатку
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Аргумент для конфігурації збірки \(за замовчуванням Release\)
ARG BUILD_CONFIGURATION=Release

# Встановлюємо робочу директорію для збірки
WORKDIR /src

# Копируем только csproj для кешируемого restore
COPY ./src/backend.csproj .

# Восстанавливаем зависимости
RUN dotnet restore backend.csproj

# Копируем исходники (всё в /app/src)
COPY ./src/ .


# Збираємо проект у вказаній конфігурації
RUN dotnet build ./backend.csproj -c $BUILD_CONFIGURATION -o /app/build

## Створюємо окремий шар для публікації додатку
FROM build AS publish

# Аргумент для конфігурації публікації \(за замовчуванням Release\)
ARG BUILD_CONFIGURATION=Release

# Публікуємо додаток у папку /app/publish без створення apphost
RUN dotnet publish "./backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Формуємо фінальний образ для запуску додатку
FROM base AS final

# Встановлюємо робочу директорію для фінального образу
WORKDIR /app

# Копіюємо опубліковані файли з шару publish
COPY --from=publish /app/publish .

# Вказуємо команду запуску додатку
ENTRYPOINT ["dotnet", "backend.dll"]
