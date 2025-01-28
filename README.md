# libraryManagementSystem

# Library Management System - API

This is a backend API for a Library Management System built using **ASP.NET Core**. The system includes features for managing users and library items (books) while demonstrating key Object-Oriented Programming (OOP) principles such as Encapsulation, Inheritance, Polymorphism, Abstraction, Exception Handling, Collections, and more.

---

## Key Concepts Covered

- **Encapsulation**: Private fields are used to restrict direct access to data, providing controlled access via public properties.
- **Properties**: Fields are accessed and validated through properties to ensure data integrity.
- **Constructors**: Used to initialize objects and enforce required data during object creation.
- **Polymorphism**: Derived classes override base methods to provide customized behavior.
- **Abstraction**: Abstract classes and methods are used to define a blueprint for derived classes.
- **Enums**: Predefined constant values that represent specific roles (Admin/Member) and book genres.
- **Collections**: Library items and users are managed in collections (lists).
- **Exception Handling**: Handles invalid inputs, missing data, and operational errors with appropriate exceptions.
- **File Handling**: Logs actions like adding books or borrowing them into a file.
- **Type Checking**: Checks the runtime type of an object to perform specific actions.

---

## Technologies Used

- **ASP.NET Core 6.0**
- **C#**
- **Entity Framework Core** (for database access)
- **Swagger** (for API documentation and testing)

---

## Project Structure

- `Models/`: Contains data models such as `User`, `Admin`, `Member`, `Book`, and `LibraryItem`.
- `Services/`: Contains business logic and methods to manage users and books (e.g., `AddBook()`, `AddUser()`, and `BorrowBook()`).
- `Controllers/`: Contains API controllers that expose endpoints for frontend interaction.

---

## Features

- **User Management**: Create, read, and manage users with Admin and Member roles.
- **Library Item Management**: Add and manage books with different formats (Physical Books and EBooks).
- **Borrowing System**: Members can borrow books, and Admins manage users.
- **Logging**: Logs actions such as adding users and borrowing books to a file.

---

## Setup Instructions

### Prerequisites

- **.NET 6.0 SDK** or later installed on your machine.
- **Visual Studio 2022** or **Visual Studio Code** (optional but recommended).

### Steps to Run the Application

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/library-management-api.git
   cd library-management-api
