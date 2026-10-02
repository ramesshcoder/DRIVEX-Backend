# 🚗 Car Rental Backend API

Backend REST API for a car rental web application, built using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The API provides the backend services required to manage cars, customers, rentals, and other car-rental related operations.

## 🧰 Tech Stack

- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **REST API**
- **LINQ**

## ✨ Features

- 🚗 Car management
- 👤 Customer management
- 📅 Rental management
- 🔄 CRUD operations
- 🗄️ SQL Server database integration
- 🔗 RESTful API endpoints
- 🧩 Entity Framework Core for database access
- ✅ Model validation
- 📦 Separation of API, business logic, and data access

## 🏗️ Architecture

The application follows a layered backend architecture:

```text
Client / Frontend
       │
       ▼
ASP.NET Core Web API
       │
       ▼
Controllers
       │
       ▼
Services / Business Logic
       │
       ▼
Entity Framework Core
       │
       ▼
SQL Server
