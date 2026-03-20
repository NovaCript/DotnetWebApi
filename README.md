# Contact Management System

Современное веб-приложение для управления списком контактов, построенное на стеке .NET 10 и React.

## 🚀 Стек технологий

*   **Backend:** C# 10+, **.NET 10.0**, ASP.NET Core Web API.
*   **Database:** SQLite + Entity Framework Core 10.
*   **Frontend:** React, Bootstrap (пагинация и формы).
*   **Библиотеки:** 
    *   `Bogus`: Генерация реалистичных тестовых данных.
    *   `Microsoft.AspNetCore.OpenApi`: Интеграция Swagger/OpenAPI.

## ✨ Функционал и особенности

*   **Полный CRUD:** Управление контактами (Name, Email) через `ContactService`.
*   **Гибкая пагинация:** Отдельный эндпоинт `/page` для постраничного вывода (по умолчанию 5 элементов).
*   **DTO Pattern:** Использование `ContactCreateDto` для входящих данных и `ContactReadDto` для ответов.
*   **Валидация:** Обработка конфликтов при создании (409 Conflict) и проверка существования при обновлении/удалении.

## 📂 Структура Backend (C#)

*   **`Controllers/`**: `ContactManagementController` наследуется от `BaseController`.
*   **`Services/`**: Инкапсуляция логики в `ContactService`.
*   **`ModelDto/`**: Объекты для передачи данных (Data Transfer Objects).
*   **`DataContext/`**: Контекст базы данных SQLite через EF Core.

## 🛠 Запуск проекта

### 1. Серверная часть (API)
```bash
cd Api
dotnet restore
dotnet run
```
*Swagger UI будет доступен по адресу: `https://localhost:[PORT]/swagger`.*

### 2. Клиентская часть (React)
```bash
cd client
npm install
npm start
```
*Приложение откроется по адресу: `http://localhost:3000`.*

## 📝 API Endpoints

Согласно спецификации Swagger (v1):


| Метод | Путь | Описание |
| :--- | :--- | :--- |
| **GET** | `/api/v1/ContactManagement/contacts` | Получить все контакты |
| **GET** | `/api/v1/ContactManagement/contacts/{id}` | Получить контакт по ID |
| **GET** | `/api/v1/ContactManagement/contacts/page` | Пагинация (`pageNumber`, `pageSize`) |
| **POST** | `/api/v1/ContactManagement/contacts` | Создать новый контакт |
| **PUT** | `/api/v1/ContactManagement/contacts/{id}` | Обновить данные контакта |
| **DELETE** | `/api/v1/ContactManagement/contacts/{id}` | Удалить контакт |

---
*Проект разработан в демонстрационных целях для работы с современным стеком .NET 10.*
