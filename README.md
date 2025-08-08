#  Student Management System 

This project is a **full-stack web application** built using **ASP.NET Core MVC** with **Entity Framework Core** for database management.  
It was developed during my **ITI Summer Training** as my graduation project in the **.NET Web Development** track.

It provides complete **CRUD operations** for managing students, courses, departments, enrollments, instructors, office assignments, and attendance — with **registration, authentication, authorization, validation, and a responsive UI**.

---

##  Technologies & Tools Used

- **ASP.NET Core MVC** – For building the web application architecture  
- **Entity Framework Core** – ORM for database operations  
- **SQL Server** – Relational database  
- **Repository Pattern** – For clean separation of business logic  
- **Dependency Injection** – For managing repository services  
- **Custom Middleware** – For request logging  
- **Action Filters** – For action logging  
- **Custom Validation Attributes** – For unique field constraints and date rules  
- **Bootstrap 5** – For responsive UI  
- **Identity (ASP.NET Core Identity)** – For authentication & authorization  
- **Razor Views & Layout** – For dynamic page rendering  
- **Remote Validation** – For server-side field validation without page reload  

---

##  Features

### ✅ User Authentication & Authorization
- Register, login, and logout functionality using **ASP.NET Identity**
- Role-based access control with `[Authorize]` attribute

###  CRUD Operations for All Entities
- Students  
- Courses  
- Departments  
- Instructors  
- Office Assignments  
- Enrollments  
- Attendance  

###  Custom Features
- Unique field validation for students, departments, instructors, and courses  
- Date validation (e.g., DOB before 2010, no future hire dates)  
- Custom middleware to log all incoming requests  
- Action filter to log controller actions  
- Repository pattern for cleaner data access layer  
- Bootstrap layout for consistent and responsive UI  
- Partial Views for shared forms (Add/Edit)  

###  Routing
- **Attribute Routing** for specific actions  
- **Conventional Routing** for default actions  
- Custom route example: `/AllStudents.com`  

###  Database
- Managed via **Entity Framework Core**  
- Relationships between entities (**One-to-Many**, **Many-to-Many**)  

---
 # How to Run the Project
- 1️⃣ Clone the repository
    git clone https://github.com/rehamhamdi/Final-MVC-Project.git
- 2️⃣ Open in Visual Studio
    Open the .sln file in Visual Studio.

- 3️⃣ Update the database connection
   Edit the connection string in ProjectDBContext.cs to match your SQL Server settings.
   
- 4️⃣ Run migrations and update the database
    Add-Migration InitialCreate
    Update-Database
- 5️⃣ Run the application
    Press F5 in Visual Studio to start the project.
---
## License
This project was developed for educational purposes as part of ITI Summer Training and is free to use for learning.


