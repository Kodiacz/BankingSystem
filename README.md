# Banking System API (Task Project)

## 📦 Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core (SQL Server)
- Dependency Injection
- JWT (JSON Web Tokens) for Authentication and Authorization

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 8](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or VS Code

## 🏗️ Project Structure (Clean Architecture)

This project follows the **Clean Architecture** approach, designed to promote separation of concerns, modularity, and testability. Below is an overview of the main layers:

### 🔹 API Layer — `BankingSystem.API`
- Acts as the **entry point** of the application.
- Hosts **controllers** responsible for handling HTTP requests and returning appropriate responses.
- Configures **middleware**, **routing**, and dependency injection.

### 🔹 Application Layer — `BankingSystem.Application`
- Contains all **business logic**, **use cases**, and **service classes** (e.g., `AuthService`, `TransactionService`).
- Defines **interfaces**, **DTOs**, **validators** and **extension methods**.
- Depends only on the **Domain Layer**, not on Infrastructure.

### 🔹 Infrastructure Layer — `BankingSystem.Infrastructure`
- Provides **implementations** for interfaces defined in the Application Layer (e.g., `IAuthRepository`, `ITransactionRepository`).
- Handles **data access**, external service integrations, file handling, etc.
- Typically includes **EF Core DbContext**, **repositories**, and configuration for persistence.

### 🔹 Domain Layer — `BankingSystem.Domain`
- The **core of the system**: contains only **entities**, **enums**, and **value objects** (e.g., `ApplicationUser`, `Transaction`, `Merchant`, `Partner` etc.).
- Free from dependencies on any other layer.
- Models the **business rules and invariants** of the application.

